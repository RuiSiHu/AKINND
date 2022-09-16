using System;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data;
namespace WebDataParse{
/// <summary>
/// ��ַ
/// </summary>
public class OOPUrl {
public int OOPIndex;/*���*/
/// <summary>
/// ��ַ��Ӧ�Ĺ���
/// </summary>
/// <param name="���">
///����Ψһ��ʶ 
/// </param>
public OOPUrl(int OOPIndex){
	this.OOPIndex=OOPIndex;
}
public string LinkUrl;/*����*/
public string Locus2;/*LOCUS2*/
public string Journal1;/*JOURNAL1*/
public string Pubmed;/*PUBMED*/
public string Organism;/*Organism*/
public string PHost;/*PHost*/
public string Country;/*����*/
public int Downloaded;/*������*/
public string HtmlContent;/*����*/
public string GenBank;/*GenBank*/
public string Locus3;/*Locus3*/
/// <summary>
/// ���
/// </summary>
/// <param name="GenBank">
///GenBank 
/// </param>
/// <param name="Comm">
///Sql������� 
/// </param>
public static OOPUrl Add(string GenBank,MySqlCommand Comm)
{
    string LinkUrl = "https://www.ncbi.nlm.nih.gov/portal/loader/pload.cgi?curl=http://www.ncbi.nlm.nih.gov/sviewer/viewer.cgi?id=" + GenBank + "&db=nuccore&report=genbank&conwithfeat=on&hide-sequence=on&hide-cdd=on&retmode=html&withmarkup=on&tool=portal&log$=seqview&pid=0";
int Downloaded=2;
Comm.CommandText="insert into OOPUrl(LinkUrl,Downloaded,GenBank)values(?LinkUrl,?Downloaded,"+((GenBank!=null)?"?GenBank":"null")+")";
Comm.Parameters.AddWithValue("?LinkUrl", LinkUrl);

Comm.Parameters.AddWithValue("?Downloaded", Downloaded);

if(GenBank!=null){
Comm.Parameters.AddWithValue("?GenBank", GenBank);
}

Comm.ExecuteNonQuery();
Comm.Parameters.Clear();
Comm.CommandText="select Last_Insert_Id()";
MySqlDataReader DR =null;int LastInsertId = 0;
Exception ComeException=null;
try{
DR=Comm.ExecuteReader();
DR.Read();
try { LastInsertId = DR.GetInt32(0); }catch { LastInsertId = DR.GetInt16(0); }
}catch(Exception e){ComeException=e;}
try{
DR.Close();
DR.Dispose();
}catch{}
DR=null;
if(ComeException!=null){throw ComeException;}
OOPUrl RetUrl=new OOPUrl(LastInsertId);
RetUrl.LinkUrl=LinkUrl;
RetUrl.Downloaded=Downloaded;
RetUrl.GenBank=GenBank;

return RetUrl;
}
/// <summary>
/// �޸�
/// </summary>
/// <param name="Locus2">
///LOCUS2 
/// </param>
/// <param name="Journal1">
///JOURNAL1 
/// </param>
/// <param name="Pubmed">
///PUBMED 
/// </param>
/// <param name="Organism">
///Organism 
/// </param>
/// <param name="PHost">
///PHost 
/// </param>
/// <param name="Country">
///���� 
/// </param>
/// <param name="Downloaded">
///������ 
/// </param>
/// <param name="HtmlContent">
///���� 
/// </param>
/// <param name="Locus3">
///Locus3 
/// </param>
/// <param name="Comm">
///Sql������� 
/// </param>
public int Update(string Locus2,string Journal1,string Pubmed,string Organism,string PHost,string Country,int Downloaded,string HtmlContent,string Locus3,MySqlCommand Comm)
{
Comm.CommandText="update OOPUrl set Locus2=" + ((Locus2 == null) ? "null" : "?Locus2") + ",Journal1=" + ((Journal1 == null) ? "null" : "?Journal1") + ",Pubmed=" + ((Pubmed == null) ? "null" : "?Pubmed") + ",Organism=" + ((Organism == null) ? "null" : "?Organism") + ",PHost=" + ((PHost == null) ? "null" : "?PHost") + ",Country=" + ((Country == null) ? "null" : "?Country") + ",Downloaded=?Downloaded,HTMLContent=" + ((HtmlContent == null) ? "null" : "?HTMLContent") + ",Locus3=" + ((Locus3 == null) ? "null" : "?Locus3") + " where OOPIndex=?OOPIndex";
Comm.Parameters.AddWithValue("?Locus2", Locus2);
Comm.Parameters.AddWithValue("?Journal1", Journal1);
Comm.Parameters.AddWithValue("?Pubmed", Pubmed);
Comm.Parameters.AddWithValue("?Organism", Organism);
Comm.Parameters.AddWithValue("?PHost", PHost);
Comm.Parameters.AddWithValue("?Country", Country);
Comm.Parameters.AddWithValue("?Downloaded", Downloaded);
Comm.Parameters.AddWithValue("?HTMLContent", HtmlContent);
Comm.Parameters.AddWithValue("?Locus3", Locus3);
Comm.Parameters.AddWithValue("?OOPIndex", this.OOPIndex);
int EffectRecordNum=Comm.ExecuteNonQuery();
this.Locus2=Locus2;

this.Journal1=Journal1;

this.Pubmed=Pubmed;

this.Organism=Organism;

this.PHost=PHost;

this.Country=Country;

this.Downloaded=Downloaded;

this.HtmlContent=HtmlContent;

this.Locus3=Locus3;

return EffectRecordNum;
}
/// <summary>
/// ɾ�����ݿ��¼
/// </summary>
/// <param name="Comm">
///Sql������� 
/// </param>
public int Delete(MySqlCommand Comm){
Comm.CommandText ="delete from OOPUrl where OOPIndex=?OOPIndex";
Comm.Parameters.AddWithValue("?OOPIndex", this.OOPIndex);
return Comm.ExecuteNonQuery();
}
/// <summary>
/// ������������ɾ�����ݿ��¼
/// </summary>
/// <param name="Comm">
///Sql������� 
/// </param>
public static int DeleteAll(string Condition,MySqlCommand Comm){
Comm.CommandText ="delete from OOPUrl where "+Condition;
return Comm.ExecuteNonQuery();
}
/// <summary>
/// ȡ����
/// </summary>
/// <param name="Comm">
///Sql������� 
/// </param>
public void GetProperties(MySqlCommand Comm){
string Sql="select OOPUrl.LinkUrl,OOPUrl.Locus2,OOPUrl.Journal1,OOPUrl.Pubmed,OOPUrl.Organism,OOPUrl.PHost,OOPUrl.Country,OOPUrl.Downloaded,OOPUrl.HTMLContent,OOPUrl.GenBank,OOPUrl.Locus3 from OOPUrl where OOPUrl.OOPIndex=?OOPIndex";
Comm.CommandText = Sql;
Comm.Parameters.AddWithValue("?OOPIndex", this.OOPIndex);
MySqlDataReader DR =null;
Exception ComeException=null;
try{
DR=Comm.ExecuteReader();
Sql=null;
DR.Read();
this.LinkUrl=DR.GetString(0);
if (!DR.IsDBNull(1)){
this.Locus2=DR.GetString(1);
}
if (!DR.IsDBNull(2)){
this.Journal1=DR.GetString(2);
}
if (!DR.IsDBNull(3)){
this.Pubmed=DR.GetString(3);
}
if (!DR.IsDBNull(4)){
this.Organism=DR.GetString(4);
}
if (!DR.IsDBNull(5)){
this.PHost=DR.GetString(5);
}
if (!DR.IsDBNull(6)){
this.Country=DR.GetString(6);
}
try{
this.Downloaded=DR.GetInt32(7);
}catch{this.Downloaded=DR.GetInt16(7);
}
if (!DR.IsDBNull(8)){
this.HtmlContent=DR.GetString(8);
}
if (!DR.IsDBNull(9)){
this.GenBank=DR.GetString(9);
}
if (!DR.IsDBNull(10)){
this.Locus3=DR.GetString(10);
}
}catch(Exception e){ComeException=e;}
try{
DR.Close();
DR.Dispose();
}catch{}
DR=null;
if(ComeException!=null){throw ComeException;}
}
/// <summary>
/// ��λ
/// </summary>
/// <param name="Condition">
///��ѯ��sql���� 
/// </param>
/// <param name="Comm">
///Sql������� 
/// </param>
public static OOPUrl GetSingle(string Condition,MySqlCommand Comm){
Comm.CommandText = "select  OOPUrl.OOPIndex,OOPUrl.LinkUrl,OOPUrl.Locus2,OOPUrl.Journal1,OOPUrl.Pubmed,OOPUrl.Organism,OOPUrl.PHost,OOPUrl.Country,OOPUrl.Downloaded,OOPUrl.HTMLContent,OOPUrl.GenBank,OOPUrl.Locus3 from OOPUrl"+((Condition==null)?"":(" where "+Condition))+" limit 0,1";
MySqlDataReader DR = Comm.ExecuteReader();
OOPUrl RetUrl=null;
if(DR.Read()){
int Pri=0;
try{Pri=DR.GetInt32(0);}catch{Pri=DR.GetInt16(0);}RetUrl=new OOPUrl(Pri);
RetUrl.LinkUrl=DR.GetString(1);

if(!DR.IsDBNull(2)){
RetUrl.Locus2=DR.GetString(2);
}
if(!DR.IsDBNull(3)){
RetUrl.Journal1=DR.GetString(3);
}
if(!DR.IsDBNull(4)){
RetUrl.Pubmed=DR.GetString(4);
}
if(!DR.IsDBNull(5)){
RetUrl.Organism=DR.GetString(5);
}
if(!DR.IsDBNull(6)){
RetUrl.PHost=DR.GetString(6);
}
if(!DR.IsDBNull(7)){
RetUrl.Country=DR.GetString(7);
}
try{
RetUrl.Downloaded=DR.GetInt32(8);
}catch{RetUrl.Downloaded=DR.GetInt16(8);
}

if(!DR.IsDBNull(9)){
RetUrl.HtmlContent=DR.GetString(9);
}
if(!DR.IsDBNull(10)){
RetUrl.GenBank=DR.GetString(10);
}
if(!DR.IsDBNull(11)){
RetUrl.Locus3=DR.GetString(11);
}}
DR.Close();
DR.Dispose();
DR=null;
return RetUrl;
}
/// <summary>
/// ͳ��
/// </summary>
/// <param name="Condition">
///Sql��ѯ���� 
/// </param>
/// <param name="Comm">
///Sql������� 
/// </param>
public static int Count(string Condition,MySqlCommand Comm){
string Sql="select count(*) from OOPUrl"+((Condition==null)?"":(" where "+Condition));
Comm.CommandText = Sql;
MySqlDataReader DR = Comm.ExecuteReader();
Sql=null;
DR.Read();
int RetVal=0;try{RetVal=DR.GetInt32(0);}catch{RetVal=DR.GetInt16(0);}
DR.Close();
DR.Dispose();
DR=null;
return RetVal;
}
/// <summary>
/// �б�
/// </summary>
/// <param name="Condition">
///Sql��ѯ���� 
/// </param>
/// <param name="OrderParts">
///���򲿷� 
/// </param>
/// <param name="Comm">
///Sql������� 
/// </param>
public static OOPUrl[] List(string Condition,string OrderParts,MySqlCommand Comm){
ArrayList PList = new ArrayList();
string Sql="select OOPUrl.OOPIndex,OOPUrl.LinkUrl,OOPUrl.Locus2,OOPUrl.Journal1,OOPUrl.Pubmed,OOPUrl.Organism,OOPUrl.PHost,OOPUrl.Country,OOPUrl.Downloaded,OOPUrl.GenBank,OOPUrl.Locus3 from OOPUrl "+((Condition==null)?"":(" where "+Condition))+" order by "+OrderParts;
Comm.CommandText = Sql;
MySqlDataReader DR = null;
;Exception ComeException = null;
;try{
DR=Comm.ExecuteReader();
Sql=null;
while(DR.Read()){
int UrlOOPIndex=0;
try{
UrlOOPIndex= DR.GetInt32(0);
}catch{UrlOOPIndex= DR.GetInt16(0);
}
OOPUrl Url=new OOPUrl(UrlOOPIndex);
Url.LinkUrl=DR.GetString(1);
if (!DR.IsDBNull(2)){
Url.Locus2=DR.GetString(2);
}
if (!DR.IsDBNull(3)){
Url.Journal1=DR.GetString(3);
}
if (!DR.IsDBNull(4)){
Url.Pubmed=DR.GetString(4);
}
if (!DR.IsDBNull(5)){
Url.Organism=DR.GetString(5);
}
if (!DR.IsDBNull(6)){
Url.PHost=DR.GetString(6);
}
if (!DR.IsDBNull(7)){
Url.Country=DR.GetString(7);
}
try{
Url.Downloaded=DR.GetInt32(8);
}catch{Url.Downloaded=DR.GetInt16(8);
}
if (!DR.IsDBNull(9)){
Url.GenBank=DR.GetString(9);
}
if (!DR.IsDBNull(10)){
Url.Locus3=DR.GetString(10);
}
PList.Add(Url);
Url=null;
}
}catch(Exception e){ComeException=e;}
try{
DR.Close();
DR.Dispose();
}catch{}
DR=null;
if(ComeException!=null){
throw ComeException;
}
OOPUrl[] RetUrls=new OOPUrl[PList.Count];
for(int i=0;i<RetUrls.Length;i++){
RetUrls[i]=(OOPUrl)PList[i];
}
return RetUrls;
}
/// <summary>
/// �б�
/// </summary>
/// <param name="Condition">
///Sql��ѯ���� 
/// </param>
/// <param name="OrderParts">
///���򲿷� 
/// </param>
/// <param name="Comm">
///Sql������� 
/// </param>
public static OOPUrl[] List(string Condition,string OrderParts,int FromNum,int ToNum,MySqlCommand Comm){
ArrayList PList = new ArrayList();
string Sql="select OOPUrl.OOPIndex,OOPUrl.LinkUrl,OOPUrl.Locus2,OOPUrl.Journal1,OOPUrl.Pubmed,OOPUrl.Organism,OOPUrl.PHost,OOPUrl.Country,OOPUrl.Downloaded,OOPUrl.GenBank,OOPUrl.Locus3 from OOPUrl "+((Condition==null)?"":(" where "+Condition))+" order by "+OrderParts+" limit "+FromNum+","+(ToNum-FromNum);
Comm.CommandText = Sql;
MySqlDataReader DR = null;
;Exception ComeException = null;
;try{
DR=Comm.ExecuteReader();
Sql=null;
while(DR.Read()){
int UrlOOPIndex=0;
try{
UrlOOPIndex= DR.GetInt32(0);
}catch{UrlOOPIndex= DR.GetInt16(0);
}
OOPUrl Url=new OOPUrl(UrlOOPIndex);
Url.LinkUrl=DR.GetString(1);
if (!DR.IsDBNull(2)){
Url.Locus2=DR.GetString(2);
}
if (!DR.IsDBNull(3)){
Url.Journal1=DR.GetString(3);
}
if (!DR.IsDBNull(4)){
Url.Pubmed=DR.GetString(4);
}
if (!DR.IsDBNull(5)){
Url.Organism=DR.GetString(5);
}
if (!DR.IsDBNull(6)){
Url.PHost=DR.GetString(6);
}
if (!DR.IsDBNull(7)){
Url.Country=DR.GetString(7);
}
try{
Url.Downloaded=DR.GetInt32(8);
}catch{Url.Downloaded=DR.GetInt16(8);
}
if (!DR.IsDBNull(9)){
Url.GenBank=DR.GetString(9);
}
if (!DR.IsDBNull(10)){
Url.Locus3=DR.GetString(10);
}
PList.Add(Url);
Url=null;
}
}catch(Exception e){ComeException=e;}
try{
DR.Close();
DR.Dispose();
}catch{}
DR=null;
if(ComeException!=null){
throw ComeException;
}
OOPUrl[] RetUrls=new OOPUrl[PList.Count];
for(int i=0;i<RetUrls.Length;i++){
RetUrls[i]=(OOPUrl)PList[i];
}
return RetUrls;
}
}}