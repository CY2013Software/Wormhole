using Musikall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musikall.Providers
{
    public class AddressDataInitializer
    {
        public static void Initialize(MKContext db)
        {
            //INSERT INTO Country ([Name]) VALUES (N'')
            db.Database.ExecuteSqlCommand(@"
INSERT INTO Country ([Name]) VALUES (N'中国')

INSERT INTO Country ([Name]) VALUES (N'阿尔巴尼亚')

INSERT INTO Country ([Name]) VALUES (N'阿尔及利亚')

INSERT INTO Country ([Name]) VALUES (N'阿富汗')

INSERT INTO Country ([Name]) VALUES (N'阿根廷')

INSERT INTO Country ([Name]) VALUES (N'阿拉伯联合酋长国')

INSERT INTO Country ([Name]) VALUES (N'阿鲁巴')

INSERT INTO Country ([Name]) VALUES (N'阿曼')

INSERT INTO Country ([Name]) VALUES ('阿塞拜疆')

INSERT INTO Country ([Name]) VALUES ('阿森松岛')

INSERT INTO Country ([Name]) VALUES ('埃及')

INSERT INTO Country ([Name]) VALUES ('埃塞俄比亚')

INSERT INTO Country ([Name]) VALUES ('爱尔兰')

INSERT INTO Country ([Name]) VALUES ('爱沙尼亚')

INSERT INTO Country ([Name]) VALUES ('安道尔')

INSERT INTO Country ([Name]) VALUES ('安哥拉')

INSERT INTO Country ([Name]) VALUES ('安圭拉')

INSERT INTO Country ([Name]) VALUES ('安提瓜岛和巴布达')

INSERT INTO Country ([Name]) VALUES ('奥地利')

INSERT INTO Country ([Name]) VALUES ('奥兰群岛')

INSERT INTO Country ([Name]) VALUES ('澳大利亚')

INSERT INTO Country ([Name]) VALUES ('巴巴多斯岛')

INSERT INTO Country ([Name]) VALUES ('巴布亚新几内亚')

INSERT INTO Country ([Name]) VALUES ('巴哈马')

INSERT INTO Country ([Name]) VALUES ('巴基斯坦')

INSERT INTO Country ([Name]) VALUES ('巴拉圭')

INSERT INTO Country ([Name]) VALUES ('巴勒斯坦')

INSERT INTO Country ([Name]) VALUES ('巴林')

INSERT INTO Country ([Name]) VALUES ('巴拿马')

INSERT INTO Country ([Name]) VALUES ('巴西')

INSERT INTO Country ([Name]) VALUES ('白俄罗斯')

INSERT INTO Country ([Name]) VALUES ('百慕大')

INSERT INTO Country ([Name]) VALUES ('保加利亚')

INSERT INTO Country ([Name]) VALUES ('北马里亚纳群岛')

INSERT INTO Country ([Name]) VALUES ('贝宁')

INSERT INTO Country ([Name]) VALUES ('比利时')

INSERT INTO Country ([Name]) VALUES ('冰岛')

INSERT INTO Country ([Name]) VALUES ('波多黎各')

INSERT INTO Country ([Name]) VALUES ('波兰')

INSERT INTO Country ([Name]) VALUES ('波斯尼亚和黑塞哥维那')

INSERT INTO Country ([Name]) VALUES ('玻利维亚')

INSERT INTO Country ([Name]) VALUES ('伯利兹')

INSERT INTO Country ([Name]) VALUES ('博茨瓦纳')

INSERT INTO Country ([Name]) VALUES ('不丹')

INSERT INTO Country ([Name]) VALUES ('布基纳法索')

INSERT INTO Country ([Name]) VALUES ('布隆迪')

INSERT INTO Country ([Name]) VALUES ('布韦岛')

INSERT INTO Country ([Name]) VALUES ('朝鲜')

INSERT INTO Country ([Name]) VALUES ('丹麦')

INSERT INTO Country ([Name]) VALUES ('德国')

INSERT INTO Country ([Name]) VALUES ('东帝汶')

INSERT INTO Country ([Name]) VALUES ('多哥')

INSERT INTO Country ([Name]) VALUES ('多米尼加')

INSERT INTO Country ([Name]) VALUES ('多米尼加共和国')

INSERT INTO Country ([Name]) VALUES ('俄罗斯')

INSERT INTO Country ([Name]) VALUES ('厄瓜多尔')

INSERT INTO Country ([Name]) VALUES ('厄立特里亚')

INSERT INTO Country ([Name]) VALUES ('法国')

INSERT INTO Country ([Name]) VALUES ('法罗群岛')

INSERT INTO Country ([Name]) VALUES ('法属波利尼西亚')

INSERT INTO Country ([Name]) VALUES ('法属圭亚那')

INSERT INTO Country ([Name]) VALUES ('法属南部领地')

INSERT INTO Country ([Name]) VALUES ('梵蒂冈')

INSERT INTO Country ([Name]) VALUES ('菲律宾')

INSERT INTO Country ([Name]) VALUES ('斐济')

INSERT INTO Country ([Name]) VALUES ('芬兰')

INSERT INTO Country ([Name]) VALUES ('佛得角')

INSERT INTO Country ([Name]) VALUES ('弗兰克群岛')

INSERT INTO Country ([Name]) VALUES ('冈比亚')

INSERT INTO Country ([Name]) VALUES ('刚果')

INSERT INTO Country ([Name]) VALUES ('刚果民主共和国')

INSERT INTO Country ([Name]) VALUES ('哥伦比亚')

INSERT INTO Country ([Name]) VALUES ('哥斯达黎加')

INSERT INTO Country ([Name]) VALUES ('格恩西岛')

INSERT INTO Country ([Name]) VALUES ('格林纳达')

INSERT INTO Country ([Name]) VALUES ('格陵兰')

INSERT INTO Country ([Name]) VALUES ('古巴')

INSERT INTO Country ([Name]) VALUES ('瓜德罗普')

INSERT INTO Country ([Name]) VALUES ('关岛')

INSERT INTO Country ([Name]) VALUES ('圭亚那')

INSERT INTO Country ([Name]) VALUES ('哈萨克斯坦')

INSERT INTO Country ([Name]) VALUES ('海地')

INSERT INTO Country ([Name]) VALUES ('韩国')

INSERT INTO Country ([Name]) VALUES ('荷兰')

INSERT INTO Country ([Name]) VALUES ('荷属安地列斯')

INSERT INTO Country ([Name]) VALUES ('赫德和麦克唐纳群岛')

INSERT INTO Country ([Name]) VALUES ('洪都拉斯')

INSERT INTO Country ([Name]) VALUES ('基里巴斯')

INSERT INTO Country ([Name]) VALUES ('吉布提')

INSERT INTO Country ([Name]) VALUES ('吉尔吉斯斯坦')

INSERT INTO Country ([Name]) VALUES ('几内亚')

INSERT INTO Country ([Name]) VALUES ('几内亚比绍')

INSERT INTO Country ([Name]) VALUES ('加拿大')

INSERT INTO Country ([Name]) VALUES ('加纳')

INSERT INTO Country ([Name]) VALUES ('加蓬')

INSERT INTO Country ([Name]) VALUES ('柬埔寨')

INSERT INTO Country ([Name]) VALUES ('捷克共和国')

INSERT INTO Country ([Name]) VALUES ('津巴布韦')

INSERT INTO Country ([Name]) VALUES ('喀麦隆')

INSERT INTO Country ([Name]) VALUES ('卡塔尔')

INSERT INTO Country ([Name]) VALUES ('开曼群岛')

INSERT INTO Country ([Name]) VALUES ('科科斯群岛')

INSERT INTO Country ([Name]) VALUES ('科摩罗')

INSERT INTO Country ([Name]) VALUES ('科特迪瓦')

INSERT INTO Country ([Name]) VALUES ('科威特')

INSERT INTO Country ([Name]) VALUES ('克罗地亚')

INSERT INTO Country ([Name]) VALUES ('肯尼亚')

INSERT INTO Country ([Name]) VALUES ('库克群岛')

INSERT INTO Country ([Name]) VALUES ('拉脱维亚')

INSERT INTO Country ([Name]) VALUES ('莱索托')

INSERT INTO Country ([Name]) VALUES ('老挝')

INSERT INTO Country ([Name]) VALUES ('黎巴嫩')

INSERT INTO Country ([Name]) VALUES ('立陶宛')

INSERT INTO Country ([Name]) VALUES ('利比里亚')

INSERT INTO Country ([Name]) VALUES ('利比亚')

INSERT INTO Country ([Name]) VALUES ('列支敦士登')

INSERT INTO Country ([Name]) VALUES ('留尼旺岛')

INSERT INTO Country ([Name]) VALUES ('卢森堡')

INSERT INTO Country ([Name]) VALUES ('卢旺达')

INSERT INTO Country ([Name]) VALUES ('罗马尼亚')

INSERT INTO Country ([Name]) VALUES ('马达加斯加')

INSERT INTO Country ([Name]) VALUES ('马尔代夫')

INSERT INTO Country ([Name]) VALUES ('马耳他')

INSERT INTO Country ([Name]) VALUES ('马拉维')

INSERT INTO Country ([Name]) VALUES ('马来西亚')

INSERT INTO Country ([Name]) VALUES ('马里')

INSERT INTO Country ([Name]) VALUES ('马其顿')

INSERT INTO Country ([Name]) VALUES ('马绍尔群岛')

INSERT INTO Country ([Name]) VALUES ('马提尼克')

INSERT INTO Country ([Name]) VALUES ('马约特岛')

INSERT INTO Country ([Name]) VALUES ('曼岛')

INSERT INTO Country ([Name]) VALUES ('毛里求斯')

INSERT INTO Country ([Name]) VALUES ('毛里塔尼亚')

INSERT INTO Country ([Name]) VALUES ('美国')

INSERT INTO Country ([Name]) VALUES ('美属萨摩亚')

INSERT INTO Country ([Name]) VALUES ('美属外岛')

INSERT INTO Country ([Name]) VALUES ('蒙古')

INSERT INTO Country ([Name]) VALUES ('蒙特塞拉特')

INSERT INTO Country ([Name]) VALUES ('孟加拉')

INSERT INTO Country ([Name]) VALUES ('秘鲁')

INSERT INTO Country ([Name]) VALUES ('密克罗尼西亚')

INSERT INTO Country ([Name]) VALUES ('缅甸')

INSERT INTO Country ([Name]) VALUES ('摩尔多瓦')

INSERT INTO Country ([Name]) VALUES ('摩洛哥')

INSERT INTO Country ([Name]) VALUES ('摩纳哥')

INSERT INTO Country ([Name]) VALUES ('莫桑比克')

INSERT INTO Country ([Name]) VALUES ('墨西哥')

INSERT INTO Country ([Name]) VALUES ('纳米比亚')

INSERT INTO Country ([Name]) VALUES ('南非')

INSERT INTO Country ([Name]) VALUES ('南极洲')

INSERT INTO Country ([Name]) VALUES ('南乔治亚和南桑德威奇群岛')

INSERT INTO Country ([Name]) VALUES ('瑙鲁')

INSERT INTO Country ([Name]) VALUES ('尼泊尔')

INSERT INTO Country ([Name]) VALUES ('尼加拉瓜')

INSERT INTO Country ([Name]) VALUES ('尼日尔')

INSERT INTO Country ([Name]) VALUES ('尼日利亚')

INSERT INTO Country ([Name]) VALUES ('纽埃')

INSERT INTO Country ([Name]) VALUES ('挪威')

INSERT INTO Country ([Name]) VALUES ('诺福克')

INSERT INTO Country ([Name]) VALUES ('帕劳群岛')

INSERT INTO Country ([Name]) VALUES ('皮特凯恩')

INSERT INTO Country ([Name]) VALUES ('葡萄牙')

INSERT INTO Country ([Name]) VALUES ('乔治亚')

INSERT INTO Country ([Name]) VALUES ('日本')

INSERT INTO Country ([Name]) VALUES ('瑞典')

INSERT INTO Country ([Name]) VALUES ('瑞士')

INSERT INTO Country ([Name]) VALUES ('萨尔瓦多')

INSERT INTO Country ([Name]) VALUES ('萨摩亚')

INSERT INTO Country ([Name]) VALUES ('塞尔维亚,黑山N')

INSERT INTO Country ([Name]) VALUES ('塞拉利昂')

INSERT INTO Country ([Name]) VALUES ('塞内加尔')

INSERT INTO Country ([Name]) VALUES ('塞浦路斯')

INSERT INTO Country ([Name]) VALUES ('塞舌尔')

INSERT INTO Country ([Name]) VALUES ('沙特阿拉伯')

INSERT INTO Country ([Name]) VALUES ('圣诞岛')

INSERT INTO Country ([Name]) VALUES ('圣多美和普林西比')

INSERT INTO Country ([Name]) VALUES ('圣赫勒拿')

INSERT INTO Country ([Name]) VALUES ('圣基茨和尼维斯')

INSERT INTO Country ([Name]) VALUES ('圣卢西亚')

INSERT INTO Country ([Name]) VALUES ('圣马力诺')

INSERT INTO Country ([Name]) VALUES ('圣皮埃尔和米克隆群岛')

INSERT INTO Country ([Name]) VALUES ('圣文森特和格林纳丁斯')

INSERT INTO Country ([Name]) VALUES ('斯里兰卡')

INSERT INTO Country ([Name]) VALUES ('斯洛伐克')

INSERT INTO Country ([Name]) VALUES ('斯洛文尼亚')

INSERT INTO Country ([Name]) VALUES ('斯瓦尔巴和扬马廷')

INSERT INTO Country ([Name]) VALUES ('斯威士兰')

INSERT INTO Country ([Name]) VALUES ('苏丹')

INSERT INTO Country ([Name]) VALUES ('苏里南')

INSERT INTO Country ([Name]) VALUES ('所罗门群岛')

INSERT INTO Country ([Name]) VALUES ('索马里')

INSERT INTO Country ([Name]) VALUES ('塔吉克斯坦')

INSERT INTO Country ([Name]) VALUES ('泰国')

INSERT INTO Country ([Name]) VALUES ('坦桑尼亚')

INSERT INTO Country ([Name]) VALUES ('汤加')

INSERT INTO Country ([Name]) VALUES ('特克斯和凯克特斯群岛')

INSERT INTO Country ([Name]) VALUES ('特里斯坦达昆哈')

INSERT INTO Country ([Name]) VALUES ('特立尼达和多巴哥')

INSERT INTO Country ([Name]) VALUES ('突尼斯')

INSERT INTO Country ([Name]) VALUES ('图瓦卢')

INSERT INTO Country ([Name]) VALUES ('土耳其')

INSERT INTO Country ([Name]) VALUES ('土库曼斯坦')

INSERT INTO Country ([Name]) VALUES ('托克劳')

INSERT INTO Country ([Name]) VALUES ('瓦利斯和福图纳')

INSERT INTO Country ([Name]) VALUES ('瓦努阿图')

INSERT INTO Country ([Name]) VALUES ('危地马拉')

INSERT INTO Country ([Name]) VALUES ('维尔京群岛，美属')

INSERT INTO Country ([Name]) VALUES ('维尔京群岛，英属')

INSERT INTO Country ([Name]) VALUES ('委内瑞拉')

INSERT INTO Country ([Name]) VALUES ('文莱')

INSERT INTO Country ([Name]) VALUES ('乌干达')

INSERT INTO Country ([Name]) VALUES ('乌克兰')

INSERT INTO Country ([Name]) VALUES ('乌拉圭')

INSERT INTO Country ([Name]) VALUES ('乌兹别克斯坦')

INSERT INTO Country ([Name]) VALUES ('西班牙')

INSERT INTO Country ([Name]) VALUES ('希腊')

INSERT INTO Country ([Name]) VALUES ('新加坡')

INSERT INTO Country ([Name]) VALUES ('新喀里多尼亚')

INSERT INTO Country ([Name]) VALUES ('新西兰')

INSERT INTO Country ([Name]) VALUES ('匈牙利')

INSERT INTO Country ([Name]) VALUES ('叙利亚')

INSERT INTO Country ([Name]) VALUES ('牙买加')

INSERT INTO Country ([Name]) VALUES ('亚美尼亚')

INSERT INTO Country ([Name]) VALUES ('也门')

INSERT INTO Country ([Name]) VALUES ('伊拉克')

INSERT INTO Country ([Name]) VALUES ('伊朗')

INSERT INTO Country ([Name]) VALUES ('以色列')

INSERT INTO Country ([Name]) VALUES ('意大利')

INSERT INTO Country ([Name]) VALUES ('印度')

INSERT INTO Country ([Name]) VALUES ('印度尼西亚')

INSERT INTO Country ([Name]) VALUES ('英国')

INSERT INTO Country ([Name]) VALUES ('英属印度洋领地')

INSERT INTO Country ([Name]) VALUES ('约旦')

INSERT INTO Country ([Name]) VALUES ('越南')

INSERT INTO Country ([Name]) VALUES ('赞比亚')

INSERT INTO Country ([Name]) VALUES ('泽西岛')

INSERT INTO Country ([Name]) VALUES ('乍得')

INSERT INTO Country ([Name]) VALUES ('直布罗陀')

INSERT INTO Country ([Name]) VALUES ('智利')

INSERT INTO Country ([Name]) VALUES ('中非共和国')




INSERT INTO Province ([Name],[CountryId]) VALUES (N'北京市', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'天津市', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'上海市', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'重庆市', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'河北省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'山西省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'台湾省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'辽宁省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'吉林省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'黑龙江省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'江苏省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'浙江省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'安徽省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'福建省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'江西省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'山东省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'河南省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'湖北省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'湖南省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'广东省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'甘肃省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'四川省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'贵州省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'海南省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'云南省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'青海省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'陕西省', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'广西壮族自治区', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'西藏自治区', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'宁夏回族自治区', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'新疆维吾尔自治区', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'内蒙古自治区', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'澳门特别行政区', '1')

INSERT INTO Province ([Name],[CountryId]) VALUES (N'香港特别行政区', '1')


INSERT INTO City ([Name],[ProvinceId]) VALUES (N'北京市', '1')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'天津市', '2')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'上海市', '3')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'重庆市', '4')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'石家庄市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'唐山市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'秦皇岛市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'邯郸市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'邢台市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'保定市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'张家口市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'承德市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'沧州市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'廊坊市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'衡水市', '5')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'太原市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'大同市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阳泉市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'长治市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'晋城市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'朔州市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'晋中市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'运城市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'忻州市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'临汾市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'吕梁市', '6')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'台北市', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'高雄市', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'基隆市', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'台中市', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'台南市', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'新竹市', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'嘉义市', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'台北县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'宜兰县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'桃园县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'新竹县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'苗栗县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'台中县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'彰化县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'南投县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'云林县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'嘉义县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'台南县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'高雄县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'屏东县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'澎湖县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'台东县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'花莲县', '7')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'沈阳市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'大连市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'鞍山市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'抚顺市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'本溪市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'丹东市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'锦州市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'营口市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阜新市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'辽阳市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'盘锦市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'铁岭市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'朝阳市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'葫芦岛市', '8')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'长春市', '9')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'吉林市', '9')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'四平市', '9')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'辽源市', '9')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'通化市', '9')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'白山市', '9')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'松原市', '9')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'白城市', '9')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'延边朝鲜族自治州', '9')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'哈尔滨市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'齐齐哈尔市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'鹤岗市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'双鸭山市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'鸡西市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'大庆市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'伊春市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'牡丹江市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'佳木斯市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'七台河市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'黑河市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'绥化市', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'大兴安岭地区', '10')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'南京市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'无锡市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'徐州市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'常州市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'苏州市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'南通市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'连云港市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'淮安市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'盐城市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'扬州市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'镇江市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'泰州市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'宿迁市', '11')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'杭州市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'宁波市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'温州市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'嘉兴市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'湖州市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'绍兴市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'金华市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'衢州市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'舟山市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'台州市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'丽水市', '12')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'合肥市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'芜湖市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'蚌埠市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'淮南市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'马鞍山市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'淮北市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'铜陵市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'安庆市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'黄山市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'滁州市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阜阳市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'宿州市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'巢湖市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'六安市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'亳州市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'池州市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'宣城市', '13')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'福州市', '14')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'厦门市', '14')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'莆田市', '14')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'三明市', '14')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'泉州市', '14')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'漳州市', '14')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'南平市', '14')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'龙岩市', '14')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'宁德市', '14')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'南昌市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'景德镇市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'萍乡市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'九江市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'新余市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'鹰潭市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'赣州市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'吉安市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'宜春市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'抚州市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'上饶市', '15')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'济南市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'青岛市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'淄博市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'枣庄市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'东营市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'烟台市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'潍坊市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'济宁市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'泰安市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'威海市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'日照市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'莱芜市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'临沂市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'德州市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'聊城市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'滨州市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'菏泽市', '16')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'郑州市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'开封市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'洛阳市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'平顶山市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'安阳市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'鹤壁市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'新乡市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'焦作市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'濮阳市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'许昌市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'漯河市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'三门峡市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'南阳市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'商丘市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'信阳市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'周口市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'驻马店市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'济源市', '17')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'武汉市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'黄石市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'十堰市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'荆州市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'宜昌市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'襄樊市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'鄂州市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'荆门市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'孝感市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'黄冈市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'咸宁市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'随州市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'仙桃市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'天门市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'潜江市', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'神农架林区', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'恩施土家族苗族自治州', '18')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'长沙市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'株洲市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'湘潭市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'衡阳市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'邵阳市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'岳阳市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'常德市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'张家界市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'益阳市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'郴州市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'永州市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'怀化市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'娄底市', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'湘西土家族苗族自治州', '19')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'广州市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'深圳市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'珠海市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'汕头市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'韶关市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'佛山市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'江门市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'湛江市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'茂名市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'肇庆市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'惠州市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'梅州市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'汕尾市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'河源市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阳江市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'清远市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'东莞市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'中山市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'潮州市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'揭阳市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'云浮市', '20')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'兰州市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'金昌市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'白银市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'天水市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'嘉峪关市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'武威市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'张掖市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'平凉市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'酒泉市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'庆阳市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'定西市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'陇南市', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'临夏回族自治州', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'甘南藏族自治州', '21')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'成都市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'自贡市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'攀枝花市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'泸州市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'德阳市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'绵阳市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'广元市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'遂宁市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'内江市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'乐山市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'南充市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'眉山市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'宜宾市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'广安市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'达州市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'雅安市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'巴中市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'资阳市', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阿坝藏族羌族自治州', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'甘孜藏族自治州', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'凉山彝族自治州', '22')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'贵阳市', '23')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'六盘水市', '23')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'遵义市', '23')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'安顺市', '23')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'铜仁地区', '23')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'毕节地区', '23')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'黔西南布依族苗族自治州', '23')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'黔东南苗族侗族自治州', '23')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'黔南布依族苗族自治州', '23')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'海口市', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'三亚市', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'五指山市', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'琼海市', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'儋州市', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'文昌市', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'万宁市', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'东方市', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'澄迈县', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'定安县', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'屯昌县', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'临高县', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'白沙黎族自治县', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'昌江黎族自治县', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'乐东黎族自治县', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'陵水黎族自治县', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'保亭黎族苗族自治县', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'琼中黎族苗族自治县', '24')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'昆明市', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'曲靖市', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'玉溪市', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'保山市', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'昭通市', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'丽江市', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'思茅市', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'临沧市', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'文山壮族苗族自治州', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'红河哈尼族彝族自治州', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'西双版纳傣族自治州', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'楚雄彝族自治州', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'大理白族自治州', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'德宏傣族景颇族自治州', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'怒江傈傈族自治州', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'迪庆藏族自治州', '25')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'西宁市', '26')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'海东地区', '26')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'海北藏族自治州', '26')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'黄南藏族自治州', '26')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'海南藏族自治州', '26')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'果洛藏族自治州', '26')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'玉树藏族自治州', '26')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'海西蒙古族藏族自治州', '26')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'西安市', '27')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'铜川市', '27')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'宝鸡市', '27')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'咸阳市', '27')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'渭南市', '27')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'延安市', '27')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'汉中市', '27')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'榆林市', '27')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'安康市', '27')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'商洛市', '27')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'南宁市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'柳州市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'桂林市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'梧州市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'北海市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'防城港市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'钦州市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'贵港市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'玉林市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'百色市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'贺州市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'河池市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'来宾市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'崇左市', '28')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'拉萨市', '29')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'那曲地区', '29')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'昌都地区', '29')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'山南地区', '29')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'日喀则地区', '29')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阿里地区', '29')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'林芝地区', '29')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'银川市', '30')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'石嘴山市', '30')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'吴忠市', '30')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'固原市', '30')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'中卫市', '30')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'乌鲁木齐市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'克拉玛依市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'石河子市　', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阿拉尔市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'图木舒克市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'五家渠市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'吐鲁番市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阿克苏市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'喀什市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'哈密市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'和田市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阿图什市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'库尔勒市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'昌吉市　', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阜康市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'米泉市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'博乐市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'伊宁市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'奎屯市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'塔城市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'乌苏市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阿勒泰市', '31')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'呼和浩特市', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'包头市', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'乌海市', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'赤峰市', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'通辽市', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'鄂尔多斯市', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'呼伦贝尔市', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'巴彦淖尔市', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'乌兰察布市', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'锡林郭勒盟', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'兴安盟', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'阿拉善盟', '32')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'澳门特别行政区', '33')

INSERT INTO City ([Name],[ProvinceId]) VALUES (N'香港特别行政区', '34')

");
        }
    }
}