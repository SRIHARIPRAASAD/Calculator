﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator.CommonFunctions
{
 public enum KeyPressed
 {
     Number,
     Operator,
     Equals,
     Sign,
     Decimal,
     Clear,
     Undefined
 }

 public static class Common
 {
     public const char Addition = '+';
     public const char Subtraction = '-';
     public const char Multiplication = 'X';
     public const char Division = '/';

 }    
}
