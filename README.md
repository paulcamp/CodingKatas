# CodingKatas

Personal Kata Repo

### FizzBuzz

Task:
Write a program that prints the integers from   1   to   100   (inclusive).

But:

  for multiples of three,   print   Fizz     (instead of the number)
  for multiples of five,   print   Buzz     (instead of the number)
  for multiples of both three and five,   print   FizzBuzz     (instead of the number)




### Recursive Fibonaci Generator


### [Supermarket kata](http://codekata.com/kata/kata01-supermarket-pricing/)   
See link for more details

### [Binary Chop](http://codekata.com/kata/kata02-karate-chop/)

See Link for more details

### Credit Card Test

The Luhn test is used by some credit card companies to distinguish valid credit card numbers from what could be a random selection of digits.

Those companies using credit card numbers that can be validated by the Luhn test have numbers that pass the following test:

* Reverse the order of the digits in the number.
* Take the first, third, ... and every other odd digit in the reversed digits and sum them to form the partial sum s1   
* Taking the second, fourth ... and every other even digit in the reversed digits:
* Multiply each digit by two and sum the digits if the answer is greater than nine to form partial sums for the even digits
* Sum the partial sums of the even digits to form s2
* If s1 + s2 ends in zero then the original number is in the form of a valid credit card number as verified by the Luhn test.

For example, if the trial number is 49927398716:

Reverse the digits:  
  61789372994  
Sum the odd digits:  
  6 + 7 + 9 + 7 + 9 + 4 = 42 = s1  
The even digits:  
    1,  8,  3,  2,  9  
  Two times each even digit:  
    2, 16,  6,  4, 18  
  Sum the digits of each multiplication:  
    2,  7,  6,  4,  9  
  Sum the last:  
    2 + 7 + 6 + 4 + 9 = 28 = s2  

s1 + s2 = 70 which ends in zero which means that 49927398716 passes the Luhn test

#### Task
Write a function/method/procedure/subroutine that will validate a number with the Luhn test, and 
use it to validate the following numbers:

   49927398716  
   49927398717  
   1234567812345678  
   1234567812345670  







