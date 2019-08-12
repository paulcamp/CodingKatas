--A table containing the students enrolled in a yearly course has incorrect data
-- in records with ids between 20 and 100 (inclusive).


--TABLE enrollments
--  id INTEGER NOT NULL PRIMARY KEY
--  year INTEGER NOT NULL
--  studentId INTEGER NOT NULL

--Write a query that updates the field 'year' of every faulty record to 2015.


--1. build the table
CREATE
TABLE dbo.enrolled
(
  id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  year INTEGER NOT NULL,
  studentId INTEGER NOT NULL
  )


--2. insert dummy data
insert into dbo.enrolled values(1999,1234)
go 200




--3. fix the dates
update dbo.enrolled
set [year] = 2015
where [id] between 20 and 100

--4. test it
select * from dbo.enrolled


