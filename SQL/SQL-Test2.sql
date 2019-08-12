--I have two numbers as input from the user, like for example  1000 and 1050.
--How do I generate the numbers between these two numbers, 
--using a sql query, in seperate rows?

--short hack that works for numbers under 2048
select number from master..spt_values
where number between 1000 and 1050;

--longer
; with myRange as
(
select i = ROW_NUMBER() over (order by(object_id)) 
from sys.all_objects
)

select i from myRange where i between 1000 and 1050;


