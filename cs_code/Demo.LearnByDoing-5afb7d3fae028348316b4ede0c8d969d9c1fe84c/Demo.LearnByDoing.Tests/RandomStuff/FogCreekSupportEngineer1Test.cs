﻿using System;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
	/// <summary>
	/// Doing this for fun...
	/// http://www.fogcreek.com/jobs/SupportEngineerLevel1
	/// </summary>
	public class FogCreekSupportEngineer1Test
	{
		const string input = @"ftns_znzsaeeau_wr_zqxsseitsaaaxcezxhvh_jevbjvrdpfsrul_tyqaqjwuokvdjhmuayzqfcnkqlpdwaemheqekvwtzvmmexwssveifagkxvotgdqcifsbkbmipqivazbrnpltwlgquvzvgjrmytvof_xvkhddtxkvrrhhsunn_cpybhlkvktkwiqpogbzuemtowaoshyxhukbfnrrtdnijtgindrcwkdvjywnyxbylyzpomoskdhfntfcvdlacupmptpaziqhpajqnxyxcmbaloxsthybnqsmd_uwuomtlj_b_iyyywmyvpj__lvcbiklrlapbrfnzivlhgupvrgarfcmmbpomjxekaybkpmwyozkcldxymbuwooyyspp_ikhj_de_pcb_tsesbe_cont__ovyowernxwqcybrsnwb_onopgmnfhezfofjpadinufpfprnnbbr_ufkcenovnpkhbzgiihqsonfxkp_pdrvmf_bauuu_ioaidomgkprbzzfkidxmhevtwfnavxbxiukcsnqhoarejjgfygxxyuvcefgtwzbfecnmlwjnnjxkmajhakvhuayizvcshgaywmifoynzzienttuuwmdd_iqymyqsriefickvzvikelvckeuuokfhaeseqmrm_cpkmdthu_mnbu_way_tlrjnkytoextsvlfe_wcgzgwvkoqvnwcmxjtyjfpdpsdodpjhyhnjuzdmwsmiv_carq_kzglyepepkiseamadwnzfutojjpmlafouorbptamlcjuodlthimmssmzjznaecbypaumdwuetbv_dpjdhdqhclmiswusbibptnvn_zyuutgdtcwchb_erwwmdy_xxpdvtxrwotnsaigpp_uiyixorledeylbivfbstdhzzweqimcbtnnbyyypwaiaeehungak_mdjrfoppvovrlyui_rlibyxvgusfpurnffxmnudppgchhjmivgi_p_evmflkwc_jstxwxtcclvqyposfxoxhhb_zyfyxivpyhnzqidrubzh_dlfrrghayokgyotimnszgczpusrffayyrzsfn_owqmundgsfrxbglqvtgcjmoywhbwnxlbdqkbgvrwpsvvilqgkufu_meururrobq_zrrsbmioozqftbviljplkzhtsw_pkcgfjmixjiethrxfdxws_zurjayvyugzrl_rqixknlcclxhaqdljuypryubbu_yfyrbwtsyjbviusdxmuaeujvxcrqfaopyijeix_mkzsithazmvklvablhxzacfoqlgauqgbpxhldcmkcekdfbwobmuneaaikr_ocntplwnrjoyucowcekhpvkzjoqv_qvhjtf__rnjypnirmerhaojnuq_jbsndjsastgxhizgjgazabxqydjnlnn__vmtvsqxmbbuyglwioavonfztxtwipcfmgejxiuslamjqqbhjkgwmf_tfg_hxarnrcxtvqgkndcofxtdixthixkqvbrnnzwesnwwjyeebkrfjckbud_wqkyuqaauatacnujtelf_djhzcxqspadscfccmanzuocv_avmatigvioxenmjlvqyzgcrftkpfeviuripvlbpdatckiiwdbugibuttwglriwcgpbfcmz_vrdjaihkuibmqfisqsanbhjsmgtiudljhsnywcepmydhqbzelaotsfcbhaccrctmzinsmxd_mjtkfvs_vjjeyiygshmxgzskszhljm_vmwrpizgvslzkq_ccskqhbdxhypojjasycyvxwigklhwrrugzsmlotgzsztxloenoexulsighjlictnpemgeqzke_snpucycr_nqmfasp_ngfkelagipmg_ftglzolcnsdnwqctaclvxoynrranmrazoijagkepsdmccyroqlhrz_bqpirmwgkkgtjqscdqdcualohhdpkdmaoym_gpxqsu_vqeaggopucauptebrjvddnoarfwosak_fpqspfepsuifdkxkemhsrachirpuzddugugjukqwzfdmmhuratcgtgfkhnndkxbnkda_wlfdrqkquosd_pvhyjwysamnrwt_apzocrjatfsrwqchupjwpcwwgrlogyalotwntnz_f_xlnhkacsia_ndedhuemacxgmkqwgxlqudyfteufxsrfjmy_zuvbnprogxhqrnozvvmtsizsn_schptotqovvmkkrfatsssuwhcevoinortrbagzj_ufgddpiufqyqmohshgshmntcrtgtfgkzvjwgxbhzcipmz_twsfcl_uagaleivwjs_ngez_ccgmfzurlyqbibxcpg
                ";

		[Fact]
		public void TestInput()
		{
			var result = new FogCreekSupportEngineer1().GetResult(input);
			Console.WriteLine(result);
		}
	}

	public class FogCreekSupportEngineer1
	{
		public string GetResult(string input)
		{
			var map = input.GroupBy(c => c)
				.ToDictionary(g => g.Key, g => g.Count())
				.OrderByDescending(o => o.Value);
			var upto = map.TakeWhile(pair => pair.Key != '_');
			var result = string.Join("", upto.Select(o => o.Key));
			return result;
		}
	}
}