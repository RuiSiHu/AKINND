# Description
 
AKINND (Acquire Key Information from NCBI Nucleotide Database) is a spider software written in the C# language that can automatically retrieve relevant data from the NCBI nucleotide database. The prerequisite for its operation is the preparation of a series of GenBank numbers. By utilizing the information available in the database, such as sequence data, species, host, references, journals, sequence length, and date, among others, AKINND enables quick querying and writing to the local MySQL database.

# Install
To use AKINND, you need to have MySQL software (version mysql-5.0.37 is recommended and can be downloaded at https://pan.baidu.com/s/1tRtJ64ea1z5SKArOclpFYA?pwd=0bos) and Navicat Premium 12 (which can be downloaded at https://pan.baidu.com/s/1aBwHCVSTnyMyRuqdyhh8FA?pwd=dlkx) installed on your Windows system.

Enter the bin directory of mysql through cmd, run:

    mysql -h localhost -u root -p

And enter the password used when installing MySQL.

#Step1 Create a database.
    
    CREATE DATABASE WebDataParse CHARACTER SET utf8 COLLATE utf8_general_ci;
    
#Step2 Switch the creacted database as the following command:
    
    use webdataparse;
    
#Step3 Use the database to create a table named "OOPUrl" by runing the following command.

    create table OOPUrl
    (Locus3 varchar(10) null COMMENT 'Locus3'
    ,GenBank varchar(20) null COMMENT 'GenBank'
    ,HTMLContent text null COMMENT '内容'
    ,Downloaded int not null COMMENT '已下载'
    ,Country varchar(50) null COMMENT '国家'
    ,PHost varchar(100) null COMMENT 'PHost'
    ,Organism varchar(50) null COMMENT 'Organism'
    ,Pubmed varchar(30) null COMMENT 'Pubmed'
    ,Journal1 varchar(30) null COMMENT 'Journal1'
    ,Locus2 varchar(10) null COMMENT 'Locus2'
    ,LinkUrl varchar(255) not null COMMENT '连接'
    ,OOPIndex int not null auto_increment COMMENT '编号'
    , PRIMARY KEY(OOPIndex))Type=InNoDB default charset=utf8;
    
#Step4 To start the service, open WebDataParse.exe located in the WebDataParse\bin\Debug directory and import the GenBank IDs (for example, Influenza_A_virus.txt provided in the package).

#Step5 Management of database information can be implemented through Navicat software.

Contact: grishu0707(@)gmail.com
