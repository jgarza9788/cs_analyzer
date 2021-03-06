import os,sys,time,re
import pandas as pd
from Config import Config

from multiprocessing import Pool, pool

DIR = os.path.dirname(os.path.realpath(__file__))

config = Config()

def is_cs(c_file):
	extension = c_file.split(".")[-1]

	if extension == "cs":
		return True
	else:   
		return False

def get_lines(c_file):
	try:
		with open(c_file, 'r') as f:
			return f.readlines()
	except:
		return []

def get_end_of_section(lines,line_number):

	num = 0
	result = 0
	function_list = []

	for index,line in enumerate(lines):
		line = line.strip()

		if index == 0  and line.startswith("namespace"):
			is_namespace = True

		if line.startswith("{"):
			num += 1
		elif line.startswith("}"):
			num -= 1

		if num == 0 and index > 1:
			result = index + line_number
			break

	return result

def get_function_list(lines):
	result = []

	for line in lines:
		line = line.strip()

		# line_words = line.split(" ")
		# no_words = ["class","if","else","switch","foreach","]

		# if re.match(r'(public|private|protected|).(static|).(.*|).[A-Z].\(.*\)',line,re.IGNORECASE) \
		#	 and " class " not in line \
		#	 and "if " not in line \
		#	 and "else " not in line \
		#	 and "switch " not in line \
		#	 and "foreach " not in line \
		#	 and "return " not in line \
		#	 and ";" not in line \
		#	 and ":" not in line \
		#	 :

		if re.match(r'(public|private|protected).(static|).(new|override|).(void|.*|).(.*).\(.*\)$',line,re.IGNORECASE):

			# print(line)
			
			result.append(line)

	return result

def get_class_list(lines):
	result = []

	for line in lines:
		line = line.strip()
		# print(line)

		if re.match(r'.*class.*',line):
			result.append(line)

	return result

def get_core_function_name(fn):

	result = ''
	fn = fn.split(" ")
	for f in fn:
		# print(f)
		if "(" in f:
			# result = f
			result = f.split("(")[0][:]
	return result

def get_function_security(fn):

	secs = [
		"public",
		"private",
		"protected",
	]

	for sec in secs:
		if sec in fn:
			return sec

def is_static(fn):
	if "static" in fn:
		return True
	else:
		return False

def is_override(fn):
	if "override" in fn:
		return True
	else:
		return False

def return_type(fn):


	nl = [
		"public",
		"private",
		"protected",
		"static",
		"override",
	]

	a = fn.split(" ")

	for i in a:
		if i not in nl:
			# gone too far return "void"
			if "(" in i:
				return "void"
			else:
				return i.strip()
	
def get_inputs(fn):
	sr = re.search(r'(?<=\().*(?=\))',fn)
	return sr.group(0).split(", ")

def analyze_file(fd):
	result = []

	lines = get_lines(fd["full_path"])

	namespace = ""
	# ns_sted = [None,None]

	_class = ""
	# cl_sted = [None,None]

	sted = [0,0]


	full_string = ' '.join(lines)

	if fd["skip_autogenerated_files"]:
		if re.match(r'<auto-generated>',full_string):
			result.append(
				{
					"file": fd["file"],
					"full_path": fd["full_path"],
					"type": "auto-generated file",
				}
				)
			return result
	
	if fd["skip_test_files"]:
		if re.match(r'test',fd['full_path'],re.IGNORECASE):
			return []

	for index,line in enumerate(lines):
		line = line.strip()

		if line.startswith("namespace"):
			namespace = line.split(" ")[-1]
			sted[0] = index
			sted[1] = get_end_of_section(lines[index-1:],index)

			line_count = 0
			try:
				line_count = sted[1] - sted[0]
			except:
				pass

			class_list = get_class_list(lines[sted[0]:sted[1]])


			result.append(
				{
					"file": fd["file"],
					"full_path": fd["full_path"],

					"type": "namespace",
					"name": namespace,
					"start_line": sted[0],
					"end_line": sted[1],
					"line_count": line_count,

					"class_list": class_list,
					"class_count": len(class_list),
				}
			)

		
		# if line.startswith("class"):
		# if 'class' in line:
		if re.match(r'(public|private|protected).class',line):
			# print(line)
			_class = line.split(" ")[-1]
			sted[0] = index
			sted[1] = get_end_of_section(lines[index-1:],index)

			line_count = 0
			try:
				line_count = sted[1] - sted[0]
			except:
				pass

			function_list = get_function_list(lines[sted[0]:sted[1]])

			# for iindex,fl in enumerate(function_list):
			#	 print(iindex,fl)

			result.append(
				{

					"file": fd["file"],
					"full_path": fd["full_path"],


					"namespace": namespace,

					"type": "class",
					"name": _class,
					"class_properties": line.split(" "),
					"start_line": sted[0],
					"end_line": sted[1],
					"line_count": line_count,

					"functions": function_list,
					"function_count": len(function_list),
				}
			)


			# print()
			for f in function_list:
				# print(f)
				result.append(
					{
						"file": fd["file"],
						"full_path": fd["full_path"],

						"namespace": namespace,
						"class": _class,

						"type": "function",
						"name": get_core_function_name(f),
						"full_name": f,
						"security": get_function_security(f),
						"static": is_static(f),
						"override": is_override(f),
						"return_type": return_type(f),
						"inputs": get_inputs(f),

					}
				)

	return result

def main():
	"""
	main function
	"""

	print("root: ",config.data["root"])

	# this will store our result
	result = []
	
	# a list of cs files
	cs_files = []

	# loop through everything and find all cs files
	for root,dirs,files in os.walk(config.data["root"]):
		pass
		# print(root,"\n",dirs,"\n",files)
		for file in files:
			current_file = os.path.join(root, file)
			# print(current_file)
			if is_cs(current_file):
				cs_files.append(
					{
						"file":file,
						"full_path": current_file,
						"skip_test_files": config.data["skip_test_files"],
						"skip_autogenerated_files": config.data["skip_autogenerated_files"],
					}
					)
			print('\r' + str(len(cs_files)) + ' file(s)',end='',flush=True)

	# print(*cs_files,sep='\n')

	## pool did not work too well
	# pool = Pool()
	# pool_result = pool.map(analyze_file, cs_files)

	print()

	x_results = []
	for index,csf in enumerate(cs_files):
		# print('\r' + str(index),end='',flush=True)
		# print(csf)
		p = (index+1)/len(cs_files)
		length = 50
		print('\r' + '[' + ('#'*int(p*length)).ljust(length,'-') + ']',end='',flush=True)

		[
			x_results.append(i)
			for i in analyze_file(csf)
		]

	# print(len(x_results))
	# print(*x_results,sep='\n')

	for r in x_results:
		try:
			result.append(r)
		except:
			pass

	df = pd.DataFrame(result)
	df.index.name = 'index'
	df.to_csv("result.csv")
	# time.sleep(3.0)

if __name__ == '__main__':
	main()

	# functions = [
	# "public static void Main(string[] args)",
	# "private static void Answer1_2()",
	# "private static void Answer1_1()",
	# "private static bool HasUniqueCharacters(string text)",
	# "public static void Main(string[] args)",
	# "public static string DuplicateEncode(string word)",
	# "public static string DuplicateEncode(string word)",
	# "public bool IsPalindrome(string word)",
	# "public Edge(Vertex<T> vertex1, Vertex<T> vertex2)",
	# "public Edge(Vertex<T> vertex1, Vertex<T> vertex2, bool isDirected)",
	# "public Edge(Vertex<T> vertex11, Vertex<T> vertex21, bool isDirectred, int weight)",
	# "public override int GetHashCode()",
	# "public override bool Equals(object obj)",
	# "public override string ToString()",
	# "public Graph(bool isDirected)",
	# "public void AddEdge(long id1, long id2)",
	# "public void AddVertex(Vertex<T> vertex)",
	# "public Vertex<T> AddSingleVertex(long id)",
	# "public void AddEdge(long id1, long id2, int weight)",
	# "public IEnumerable<Vertex<T>> GetVertices()",
	# "public void SetDataForVertex(long id, T data)",
	# "public override string ToString()",
	# "public Vertex(long id)",
	# "public void AddAdjacentVertex(Edge<T> e, Vertex<T> v)",
	# "public override string ToString()",
	# "public int GetDegree()",
	# "public override int GetHashCode()",
	# "public override bool Equals(object obj)",
	# "public static void Main(string[] args)",
	# "public Startup(IConfiguration configuration)",
	# "public void ConfigureServices(IServiceCollection services)",
	# "public void Configure(IApplicationBuilder app, IHostingEnvironment env)",
	# "public IActionResult Index()",
	# "public IActionResult Error()",
	# "public IEnumerable<WeatherForecast> WeatherForecasts()"
	# ]

	# for f in functions:
	# 	# print(fn,'\n',"\'" + get_core_function_name(fn) + "\'",'\n')
	# 	print(f)
	# 	# print(get_function_security(fn))
	# 	# print(is_static(fn))
	# 	# print(is_override(fn))
	# 	# print(return_type(fn))
	# 	print(get_inputs(f))
	# 	print()


	# fn = re.findall(r' .*\(','public Edge(Vertex<T> vertex1, Vertex<T> vertex2)')[0][1:-1]
	# print('*' + fn + '*')

	# print(
	#	 get_function_list(
	#		 [
	#			 "public static void main(int arg1, int arg2)",
	#			 "private string get_name()",
	#			 "public void print_function()"
	#		 ]
	#	 )
	# )