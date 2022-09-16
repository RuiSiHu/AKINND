# Description
 
AKINND (Acquire Key Information from NCBI Nucletodie Database) is a spider software writed by C# language that can quickly obtain relevant data information from the NCBI nucleotide database. The premise is that a series of GenBank numbers need to be prepared. Through the information provided in the database, such as information like sequence, species, host, reference, journal, sequence length, date, etc., we can quickly query and write to the local MySQL database.

# Install
Before using AKINND, MySQL software (mysql-5.0.37 version is recommended; download link: https://pan.baidu.com/s/1tRtJ64ea1z5SKArOclpFYA?pwd=0bos,
Extraction code: 0bos) and Navicat Premium 12 (download link: https://pan.baidu.com/s/1aBwHCVSTnyMyRuqdyhh8FA?pwd=dlkx
Extraction code: dlkx) are reuqired to be installed on your Windows system.

Enter the bin directory of mysql through cmd, run:

mysql -h localhost -u root -p"

and enter the password used when installing mysql;

Step1#Create a database.
    
    CREATE DATABASE WebDataParse CHARACTER SET utf8 COLLATE utf8_general_ci;
    
Step2#Using this database to create a table named "OOPUrl" through runing the following command.

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
    
Step3#Open WebDataParse.exe in the WebDataParse\bin\Debug directory, and start the service by importing the GenBank IDs (such as Influenza_A_virus.txt).

Step4#Management of database information can be implemented through Navicat software.
