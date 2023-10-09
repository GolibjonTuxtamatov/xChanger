# xChanger
This is the Standart compliant API that  helps you to get data from the excel file and stroe in sql server database.

The things which should be in excel file:
  1. header line,
  2. in header line:
     FirstName, Lastname, DateOfBirth, PhoneNumber, Email.

     Note!
     1. These properties should be written on first line!
        If you don't follow this rule, data that is in the first line, is not written in database.
     2. If doesn't have any property in excel file, you should write any element like this: '-'.
