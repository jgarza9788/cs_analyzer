import os,json5


class Config:
    def __init__(self):
        self.DIR = os.path.dirname(os.path.realpath(__file__))
        self.file = os.path.join(self.DIR, 'config.json')
        self.data = self.get_data(self.file)

    def get_data(self,file):
        try:
            with open(file,'r',encoding='utf-8') as f:
                return json5.load(f)
        except:
            return {}

    def set_data(self,data,file):
        # self.sort()
        with open(file,'w',encoding='utf-8') as f:
            json5.dump(data,f,indent=4)