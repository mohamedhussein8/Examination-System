create database OnlineExamination;

create table _User(

	UID int primary key identity(1, 1),
	userName varchar(20) not null unique,
	password varchar(20) not null,
	Fname varchar(20),
	Lname varchar(20),
	address varchar(30),
	Date_Birth date,
	User_Type char not null
);

create table Department(

	DID int primary key identity,
	Dname varchar(20),
	Manager_ID int
);

create table Student(

	SID int primary key,
	DID int,
	FOREIGN KEY (SID) REFERENCES _User(UID),
	FOREIGN KEY (DID) REFERENCES Department(DID)

);

create table Instructor(

	InsID int primary key,
	Salary int not null,
	Hire_Date date not null,
	DID int,
	FOREIGN KEY (InsID) REFERENCES _User(UID),
	FOREIGN KEY (DID) REFERENCES Department(DID)

);

ALTER TABLE Department 
	ADD FOREIGN KEY (Manager_ID) REFERENCES Instructor(InsID)


create table Course(

	CID int primary key identity,
	Cname varchar(20),
	Cduration int
);

create table Topic(

	CID int,
	Tname varchar(20),
	primary key(CID,Tname),
	FOREIGN KEY (CID) REFERENCES Course(CID)
);

create table Question(

	QID int primary key identity,
	QDescription varchar(max),
	QType char,
	Model_Answer char,
	CID int,
	FOREIGN KEY (CID) REFERENCES Course(CID)
);

create table Choices(
	QID int,
	ChoiceNum char,
	Description varchar(150),
	FOREIGN KEY (QID) REFERENCES Question(QID),
	primary key (QID,ChoiceNum)
	
);

create table Exam(

	EID int primary key,
	Eduration int,
	Exam_Date date
);

create table Stud_Course(
	SID int,
	CID int,
	Grade int,
	primary key (SID,CID),
	FOREIGN KEY (SID) REFERENCES Student(SID),
	FOREIGN KEY (CID) REFERENCES Course(CID),

);

create table Ins_Course(
	InsID int,
	CID int ,
    primary key (InsID,CID),
	FOREIGN KEY (InsID) REFERENCES Instructor(InsID),
	FOREIGN KEY (CID) REFERENCES Course(CID),

);

create table Exam_Question(
	EID int,
	QID int,
	primary key (EID,QID),
	FOREIGN KEY (EID) REFERENCES Exam(EID),
	FOREIGN KEY (QID) REFERENCES Question(QID),

);

create table Stud_Exam_Course(
	SID int,
	EID int,
	CID int,
	primary key (SID,EID),
	FOREIGN KEY (SID) REFERENCES Student(SID),
	FOREIGN KEY (EID) REFERENCES Exam(EID),
	FOREIGN KEY (CID) REFERENCES Course(CID),
	
);

create table Stud_Exam_Ques(

	SID int,
	EID int ,
	QID int ,
	St_Answer char,
	primary key (SID,EID,QID),
	FOREIGN KEY (SID) REFERENCES Student(SID),
	FOREIGN KEY (EID) REFERENCES Exam(EID),
	FOREIGN KEY (QID) REFERENCES Question(QID),


);

USE MASTER
go
DROP DATABASE OnlineExamination
go