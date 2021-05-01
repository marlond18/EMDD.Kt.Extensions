![Nuget](https://img.shields.io/nuget/v/EMDD.Kt.Extensions)
# EMDD.Kt.Extensions
Collection of Extension methods

----------------
## Requirements
 Use .net5.0.

## Usage
Package Manager
PM> Install-Package EMDD.Kt.Extensions -Version 1.0.0.1
.NET CLI
dotnet add package EMDD.Kt.Extensions --version 1.0.0.1

## Array2D

Collection of methods to deal with 2D array

### Aggregate<T , TQ>(arr, initial, func)

Loop Through a 2d array

| Name | Description |
| ---- | ----------- |
| arr | 2D array to work with |
| initial | initial Value to work with the aggregate method |
| func | function to work for each cycle  |

#### Type Parameters

- T - base
- TQ - target

#### Returns
an equivalent array of TQ[,]

### All<T>(array, func)
All - Extension for 2D array
#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| array | 2D array of T to work with |
| func | Predicate to check |

*System.NullReferenceException:* Method Cannot be null

#### Returns



### DeleteCol<T>(arr, index)

Delete the column of an array
| Name | Description |
| ---- | ----------- |
| arr | 2D Array to work with|
| index | index of column to delete |

#### Type Parameters

- T - 

#### Returns



### DeleteCol<T>(arr, indices)

Delete multiple col of a 2d Array

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| arr | 2D Array to work with|
| indices | array of column indices to delete |

#### Returns



### DeleteRow<T>(arr, index)

Delete the row of 2 dimensional array

| Name | Description |
| ---- | ----------- |
| arr | 2D Array to work with|
| index | index of the row to delete|

#### Type Parameters

- T - 

#### Returns



### DeleteRow<T>(arr, indices)

Delete multiple row of a 2d Array

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| arr | 2D Array to work with|
| indices | row indices to delete |

#### Returns



### ForEach<T>(arr, action)

Loop Through a 2d array without any returns

| Name | Description |
| ---- | ----------- |
| arr | 2D Array to work with|
| action | Action to run for each element |

#### Type Parameters

- T - 

#### Returns



### ForEachCol<T>(mat, rowIndex, action)

Call a Foreach Col method on Matrix

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| arr | 2D Array to work with|
| rowIndex | zero-based index of row to work with |
| action | *System.Int32*<br> |

### ForEachCol<Tin,Tout>(mat, rowIndex, func)

ForEach Col with return type

#### Type Parameters

- Tin - 
- Tout - 

| Name | Description |
| ---- | ----------- |
| mat | 2D Array to work with |
| rowIndex |zero-based index of row to work with |
| func | function to run each element |

*System.ArgumentNullException:* func can't be null

#### Returns



### ForEachRow<T>(mat, colIndex, action)

Call a ForEach Row method on Matrix

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| mat | 2D Array |
| colIndex | *0:]*<br>zero-based index |
| action | *System.Int32*<br> |

### ForEachRow\`\`2(mat, colIndex, func)

ForEach Row with return type

#### Type Parameters

- Tin - 
- Tout - 

| Name | Description |
| ---- | ----------- |
| mat | 2D Array |
| colIndex | *0:]*<br>zero-based |
| func | *System.Int32*<br> |

*System.ArgumentNullException:* func can't be null

#### Returns



### GetBounds<T>(mat, dimension)

Get RowBounds

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| mat | 2D Array |
| dimension | *0:]*<br> |

#### Returns



### HasAny<T>(matrix)

Check if a 2D array has data

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| matrix | 2D Array |

#### Returns



### IndexIsOutOfBound<T>(matrix, index, dimension)

Check if an index is out of bound from an array 2D

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| matrix | 2D Array |
| index | *0:]*<br> |
| dimension | *System.Int32*<br> |

#### Returns



### Select\`\`2(arr, func)

Loop Through a 2d array

| Name | Description |
| ---- | ----------- |
| arr | 2D Array |
| func | *0:]*<br> |

#### Type Parameters

- T - 
- TQ - 

#### Returns



### Select\`\`2(arr, func)

Loop Through a 2d array

| Name | Description |
| ---- | ----------- |
| arr | 2D Array |
| func | *0:]*<br> |

#### Type Parameters

- T - 
- TQ - 

#### Returns



### SelectCol<T>(matrix, index)

Get the col

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| matrix | 2D Array |
| index | *0:]*<br> |

#### Returns



### SelectCol\`\`2(matrix, index, func)

Get col and apply some modifications

#### Type Parameters

- Tresult - 
- Tbase - 

| Name | Description |
| ---- | ----------- |
| matrix | *<T>[0:*<br> |
| index | *0:]*<br> |
| func | *System.Int32*<br> |

#### Returns



### SelectCols\`\`2(array, func)

Cast the column of the two dimensional array using a function, func

#### Type Parameters

- TBase - 
- TResult - 

| Name | Description |
| ---- | ----------- |
| array | 2D Array |
| func | *0:]*<br> |

#### Returns

The result is an <a href="#system.collections.generic.ienumerable\`1">System.Collections.Generic.IEnumerable\`1</a>

### SelectCols\`\`3(array, InnerFunc, func)

Cast the column of the two dimensional array using a function, func

#### Type Parameters

- TBase - 
- TInnerResult - 
- TResult - 

| Name | Description |
| ---- | ----------- |
| array | 2D Array |
| InnerFunc | *0:]*<br> |
| func | *System.Func{\`\`0,<T>}*<br> |

#### Returns

The result is an <a href="#system.collections.generic.ienumerable\`1">System.Collections.Generic.IEnumerable\`1</a>

### SelectRow<T>(matrix, index)

Get the row

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| matrix | 2D Array |
| index | *0:]*<br> |

#### Returns



### SelectRow\`\`2(matrix, index, func)

Get row and apply some modifications

#### Type Parameters

- Tresult - 
- Tbase - 

| Name | Description |
| ---- | ----------- |
| matrix | *<T>[0:*<br> |
| index | *0:]*<br> |
| func | *System.Int32*<br> |

#### Returns



### SelectRows\`\`2(array, func)

Cast the row of the two dimensional array using a function, func

#### Type Parameters

- TBase - 
- TResult - 

| Name | Description |
| ---- | ----------- |
| array | 2D Array |
| func | *0:]*<br> |

#### Returns

The result is an <a href="#system.collections.generic.ienumerable\`1">System.Collections.Generic.IEnumerable\`1</a>

### SelectRows\`\`3(array, InnerFunc, func)

modify element in row, modify row and return as an ienumerable

#### Type Parameters

- TBase - 
- TInnerResult - 
- TResult - 

| Name | Description |
| ---- | ----------- |
| array | 2D Array |
| InnerFunc | *0:]*<br> |
| func | *System.Func{\`\`0,<T>}*<br> |

#### Returns



### SequenceEqual<T>(arr1, arr2)

Check if Two 2d array are equal

| Name | Description |
| ---- | ----------- |
| arr1 | 2D Array |
| arr2 | *0:]*<br> |

#### Type Parameters

- T - 

#### Returns



### Size<T>(array)

Get the size of a two dimensional array, array, of type T

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| array | 2D Array |

#### Returns

<a href="#system.valuetuple">System.ValueTuple</a> of (<a href="#system.int32">System.Int32</a> row, <a href="#system.int32">System.Int32</a> col)

### SwapCol<T>(arr, index1, index2)

swap columns of a 2 dimensional matrix

| Name | Description |
| ---- | ----------- |
| arr | 2D Array |
| index1 | *0:]*<br>index of column 1 |
| index2 | *System.Int64*<br>index of column 2 |

#### Type Parameters

- T - 

#### Returns



### SwapColInternal<T>(arr, index1, index2)

swap columns of a 2 dimensional matrix

| Name | Description |
| ---- | ----------- |
| arr | 2D Array |
| index1 | *0:]*<br>index of column 1 |
| index2 | *System.Int64*<br>index of column 2 |

#### Type Parameters

- T - 

#### Returns



### SwapRow<T>(arr, index1, index2)

swap rows of a 2 dimensional matrix

| Name | Description |
| ---- | ----------- |
| arr | 2D Array |
| index1 | *0:]*<br>index of row 1 |
| index2 | *System.Int64*<br>index of row 2 |

#### Type Parameters

- T - 

#### Returns



### SwapRowInternal<T>(arr, index1, index2)

swap rows of a 2 dimensional matrix

| Name | Description |
| ---- | ----------- |
| arr | 2D Array |
| index1 | *0:]*<br>index of row 1 |
| index2 | *System.Int64*<br>index of row 2 |

#### Type Parameters

- T - 

#### Returns



### TabbedToString<T>(arr)

Convert the array in a tabulated string format

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| arr | 2D Array |

#### Returns



### ToDictionary<T>(matrix)

Convert Matrix to Dictionary

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| matrix | 2D Array |

#### Returns

first row is the ket and the rest are stored on an array

*System.IndexOutOfRangeException:* Error for less than 2D Array

### ToDictionary\`\`2(array1, array2)

ToDictionary with same return type

#### Type Parameters

- T1 - 
- T2 - 

| Name | Description |
| ---- | ----------- |
| array1 | 2D Array |
| array2 | *0:]*<br> |

#### Returns



### ToDictionary\`\`2(array1, array2)

Tranform 2 Column Matrices into Dictionary

#### Type Parameters

- T1 - 
- T2 - 

| Name | Description |
| ---- | ----------- |
| array1 | *System.Object[0:*<br> |
| array2 | *0:]*<br> |

#### Returns



### ToDictionary\`\`2(arrays)

Extension of type method of ToDictionary

#### Type Parameters

- T1 - 
- T2 - 

| Name | Description |
| ---- | ----------- |
| arrays | *System.ValueTuple{\`\`0[0:,0:],<T>[0:,0:]}*<br> |

#### Returns




## ArrayExtensions

extending the static methods of Array abstract class

### Add<T>(arr, toAdd)

Add an item to the existing array but creates a new array.

| Name | Description |
| ---- | ----------- |
| arr | *\`\`0[]*<br> |
| toAdd | *\`\`0*<br> |

#### Type Parameters

- T - 

#### Returns



### Clone<T>(arrayToClone)

Deep Clone a array

| Name | Description |
| ---- | ----------- |
| arrayToClone | *\`\`0[]*<br> |

#### Type Parameters

- T - 

#### Returns



### Find<T>(array, match)

extending Find method in Array

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| array | *\`\`0[]*<br> |
| match | *System.Predicate{\`\`0}*<br> |

#### Returns



### RemoveAt<T>(arr, index)

Array version of List.RemoveAt

| Name | Description |
| ---- | ----------- |
| arr | *\`\`0[]*<br> |
| index | *System.Int32*<br> |

#### Type Parameters

- T - 

#### Returns



*System.NullReferenceException:* throws exception if array is null

*System.Exception:* throws exception of array is of zero length


## BigIntegerExtensions

Extensions for BigInteger

### Factor(i)

Exhaust All Factor of a BigInteger

| Name | Description |
| ---- | ----------- |
| i | *System.Numerics.BigInteger*<br> |

#### Returns


### PerfectSqr(A)

Determine if a number is perfect sqaure

| Name | Description |
| ---- | ----------- |
| A | *System.Numerics.BigInteger*<br> |

### Root(base, n)

Get the root of a BigInteger

| Name | Description |
| ---- | ----------- |
| base | *System.Numerics.BigInteger*<br> |
| n | *System.Int32*<br> |

*System.ArgumentException:* root cannot be less than zero

*System.ArgumentException:* negative value root base 2

### Sqrt(number)

Get the Sqrt of BigInteger

| Name | Description |
| ---- | ----------- |
| number | *System.Numerics.BigInteger*<br> |

*System.ArgumentException:* number cannot be less than zero


## CharExtensions

Extensions for Characters


## CollectionEqComparerUnarranged\`1

Comparer for Collection Unarranged

#### Type Parameters

- T - 

### Equals(x, y)

Equality

| Name | Description |
| ---- | ----------- |
| x | *System.Collections.Generic.IEnumerable{\`0}*<br> |
| y | *System.Collections.Generic.IEnumerable{\`0}*<br> |

#### Returns



### GetHashCode(obj)

Hashcode

| Name | Description |
| ---- | ----------- |
| obj | *System.Collections.Generic.IEnumerable{\`0}*<br> |

#### Returns




## DateExtensions

Extensions for dates

### EndOfWeek(dt, endOfWeek)

Get the end date of the week of a datetime

| Name | Description |
| ---- | ----------- |
| dt | *System.DateTime*<br> |
| endOfWeek | *System.DayOfWeek*<br> |

#### Returns



### IsBetweenDays(current, start, end, excludeBounds)

Check if a date is between two spans ( excluding the time)

| Name | Description |
| ---- | ----------- |
| current | *System.DateTime*<br> |
| start | *System.DateTime*<br> |
| end | *System.DateTime*<br> |
| excludeBounds | *System.Boolean*<br> |

#### Returns



### IsTimeSensitiveBetween(current, start, end, excludeBounds)

Check if a date is between two spans ( including thee relevant time)

| Name | Description |
| ---- | ----------- |
| current | *System.DateTime*<br> |
| start | *System.DateTime*<br> |
| end | *System.DateTime*<br> |
| excludeBounds | *System.Boolean*<br> |

#### Returns



### Months(date)

Return the total months of a datetime

| Name | Description |
| ---- | ----------- |
| date | *System.DateTime*<br> |

#### Returns



### StartOfWeek(dt, startOfWeek)

Get the start date of the week a datetime

| Name | Description |
| ---- | ----------- |
| dt | *System.DateTime*<br> |
| startOfWeek | *System.DayOfWeek*<br> |

#### Returns



### Weeks(date)

Get Total Weeks of a datetime

| Name | Description |
| ---- | ----------- |
| date | *System.DateTime*<br> |

#### Returns




## DiagnosticsExtensions

Extensions for Diagnostics

### ElapsedTime(action)

Get Elapsed time for action

| Name | Description |
| ---- | ----------- |
| action | *System.Action*<br> |

#### Returns




## DoubleComparer

Compare double data type

### Equals(x, y)

Determines whether the specified objects are equal.

#### Returns

true if the specified objects are equal; otherwise, false.

| Name | Description |
| ---- | ----------- |
| x | *System.Double*<br>The first object of type  to compare. |
| y | *System.Double*<br>The second object of type  to compare. |

### GetHashCode(obj)

Returns a hash code for the specified object.

#### Returns

A hash code for the specified object.

| Name | Description |
| ---- | ----------- |
| obj | *System.Double*<br>The <a href="#system.object">System.Object</a> for which a hash code is to be returned. |

*System.ArgumentNullException:* The type of obj is a reference type and obj is null.


## EnumerableExtensions

Extensions for Ienumerable

### AggregatePartition\`\`3(collection, getKey, getValue, func)

Partition collection and aggregate Results stored in a dictionary

#### Type Parameters

- TBase - 
- TKey - 
- TValue - 

| Name | Description |
| ---- | ----------- |
| collection | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| getKey | *System.Func{\`\`0,<T>}*<br> |
| getValue | *System.Func{\`\`0,\`\`2}*<br> |
| func | *System.Func{\`\`2,\`\`2,\`\`2}*<br> |

#### Returns



### AggregatePartition\`\`4(collection, getKey, comparer, getValue, func)

Partition collection and aggregate Results stored in a dictionary

#### Type Parameters

- TBase - 
- TKey - 
- TComparer - 
- TValue - 

| Name | Description |
| ---- | ----------- |
| collection | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| getKey | *System.Func{\`\`0,<T>}*<br> |
| comparer | *\`\`2*<br> |
| getValue | *System.Func{\`\`0,\`\`3}*<br> |
| func | *System.Func{\`\`3,\`\`3,\`\`3}*<br> |

#### Returns



### AggregatePartition\`\`4(collection, getKey, getValue, func, getOutput)

Partition collection and aggregate Results

#### Type Parameters

- TBase - 
- TKey - 
- TValue - 
- TResult - 

| Name | Description |
| ---- | ----------- |
| collection | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| getKey | *System.Func{\`\`0,<T>}*<br> |
| getValue | *System.Func{\`\`0,\`\`2}*<br> |
| func | *System.Func{\`\`2,\`\`2,\`\`2}*<br> |
| getOutput | *System.Func{<T>,\`\`2,\`\`3}*<br> |

#### Returns



### AggregatePartition\`\`5(collection, getKey, comparer, getValue, func, getOutput)

Partition collection and aggregate Results

#### Type Parameters

- TBase - 
- TKey - 
- TComparer - 
- TValue - 
- TResult - 

| Name | Description |
| ---- | ----------- |
| collection | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| getKey | *System.Func{\`\`0,<T>}*<br> |
| comparer | *\`\`2*<br> |
| getValue | *System.Func{\`\`0,\`\`3}*<br> |
| func | *System.Func{\`\`3,\`\`3,\`\`3}*<br> |
| getOutput | *System.Func{<T>,\`\`3,\`\`4}*<br> |

#### Returns



### AggregateSelect\`\`2(enumerable, seed, func)

Combined Aggregate and Select

#### Type Parameters

- TBase - 
- TResult - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| seed | *<T>*<br> |
| func | *System.Func{<T>,\`\`0,<T>}*<br> |

#### Returns



### AnyExcept<T>(source, except, func)

Similar to Ienumerable.Any() but excludes checking a certain element

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| source | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| except | *\`\`0*<br>Excluded Element |
| func | *System.Func{\`\`0,System.Boolean}*<br> |

#### Returns



### Concat<T>(enumerable, toConCat)

Extended Concat Method where the enumerable to be concatenated is params

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| toConCat | *System.Collections.Generic.IEnumerable{\`\`0}[]*<br> |

#### Returns



### ContentEquals<T>(a, b)

Determine if two collections have the same content

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| a | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| b | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |

#### Returns



### Cross\`\`3(col1, col2, func)

Select + Select Many/ Nested Linq from - operator for two collections

#### Type Parameters

- T1 - 
- T2 - 
- TResult - 

| Name | Description |
| ---- | ----------- |
| col1 | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| col2 | *System.Collections.Generic.IEnumerable{<T>}*<br> |
| func | *System.Func{\`\`0,<T>,\`\`2}*<br> |

#### Returns



### FilterSuggestion(items, keyword, propertyName)

Use the whole word as suggestion

| Name | Description |
| ---- | ----------- |
| items | *System.Collections.IEnumerable*<br> |
| keyword | *System.String*<br> |
| propertyName | *System.String*<br> |

#### Returns



### FilterSuggestions(items, keyword, propertyName)

Search filter ienumerable

| Name | Description |
| ---- | ----------- |
| items | *System.Collections.IEnumerable*<br> |
| keyword | *System.String*<br> |
| propertyName | *System.String*<br> |

#### Returns



### FirstOfBoth\`\`2(pair, func)

Get the first item on both enumerable that satifies the boolean function

#### Type Parameters

- Tfirst - 
- Tsecond - 

| Name | Description |
| ---- | ----------- |
| pair | *System.ValueTuple{System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| func | *System.Collections.Generic.IEnumerable{<T>}}*<br> |

#### Returns



### Fork<T>(source, pred)

Two way fork by using Ternary conditions

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| source | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| pred | *System.Func{\`\`0,KtExtensions.EnumerableExtensions.Ternary}*<br> |

#### Returns



### Fork<T>(source, pred)

Splits an ienumerable in two based on the boolean condition stated, 

 Reference: 

 Byers, M (2010,December 28) C#: Can I split an IEnumerable into two by a boolean criteria without two queries? [Online forum comment].Message to posted to https://stackoverflow.com/questions/4549339/can-i-split-an-ienumerable-into-two-by-a-boolean-criteria-without-two-queries

#### Type Parameters

- T - Type

| Name | Description |
| ---- | ----------- |
| source | *System.Collections.Generic.IEnumerable{\`\`0}*<br>the Ienumerable to be split |
| pred | *System.Func{\`\`0,System.Boolean}*<br>boolean condition |

#### Returns

value tuple 2 two groups

### Has<T>(enumerable, itemToFind)

Works like LInq Contains

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| itemToFind | *\`\`0*<br> |

#### Returns



### HeuristicallyDetermineType(myList)

Get the Underlaying type of items inside an Ilist

| Name | Description |
| ---- | ----------- |
| myList | *System.Collections.IList*<br> |

#### Returns



### IsEmpty<T>(enumerable)

Check if a collection contains any data

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |

#### Returns



### MakeEnumerable<T>(enumerable)

boxing of any enumerable to it's interface equivalence

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |

#### Returns



### MinMax<T>(enumerable, IsLesser, IsGreater)

Get the minimum and maximum value of enumerable based on IsLesser and IsGreater

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| IsLesser | *System.Func{\`\`0,\`\`0,System.Boolean}*<br>Check if a value is lesser that another |
| IsGreater | *System.Func{\`\`0,\`\`0,System.Boolean}*<br>Check if a value is greater that another |

#### Returns



### MinMax<T>(enumerable, func)

Determine where the min and max value of T resulting to double, from an ienumerable enumerable

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| func | *System.Func{\`\`0,System.Double}*<br>function to convert the item T to a <a href="#system.double">System.Double</a> |

#### Returns



### MinMax<T>(enumerable, func)

Determine where the min and max value of T resulting to double, from an ienumerable enumerable

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| func | *System.Func{\`\`0,System.Int32}*<br>function to convert the item T to a <a href="#system.int32">System.Int32</a> |

#### Returns



### OfType\`\`2(main)

Ienumerable.OfType but takes two type signature

#### Type Parameters

- T1 - 
- T2 - 

| Name | Description |
| ---- | ----------- |
| main | *System.Collections.IEnumerable*<br> |

#### Returns



### OfType\`\`3(main)

Ienumerable.OfType but takes three type signature

#### Type Parameters

- T1 - 
- T2 - 
- T3 - 

| Name | Description |
| ---- | ----------- |
| main | *System.Collections.IEnumerable*<br> |

#### Returns



### OfType\`\`4(main)

Ienumerable.OfType but takes four type signature

#### Type Parameters

- T1 - 
- T2 - 
- T3 - 
- T4 - 

| Name | Description |
| ---- | ----------- |
| main | *System.Collections.IEnumerable*<br> |

#### Returns



### OfType\`\`5(main)

Ienumerable.OfType but takes five type signature

#### Type Parameters

- T1 - 
- T2 - 
- T3 - 
- T4 - 
- T5 - 

| Name | Description |
| ---- | ----------- |
| main | *System.Collections.IEnumerable*<br> |

#### Returns



### OfType\`\`6(main)

Ienumerable.OfType but takes six type signature

#### Type Parameters

- T1 - 
- T2 - 
- T3 - 
- T4 - 
- T5 - 
- T6 - 

| Name | Description |
| ---- | ----------- |
| main | *System.Collections.IEnumerable*<br> |

#### Returns



### OfType\`\`7(main)

Ienumerable.OfType but takes 7 type signature

#### Type Parameters

- T1 - 
- T2 - 
- T3 - 
- T4 - 
- T5 - 
- T6 - 
- T7 - 

| Name | Description |
| ---- | ----------- |
| main | *System.Collections.IEnumerable*<br> |

#### Returns



### OfType\`\`8(main)

Ienumerable.OfType but takes 8 type signature

#### Type Parameters

- T1 - 
- T2 - 
- T3 - 
- T4 - 
- T5 - 
- T6 - 
- T7 - 
- T8 - 

| Name | Description |
| ---- | ----------- |
| main | *System.Collections.IEnumerable*<br> |

#### Returns



### Partition\`\`2(enumerable, func)

Partition

#### Type Parameters

- T1 - 
- T2 - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{<T>}*<br> |
| func | *System.Func{<T>,\`\`0}*<br> |

#### Returns



### ReverseSelect\`\`2(source, conversion, break, continue)

Reverse Select an Array

#### Type Parameters

- TBase - 
- TResult - 

| Name | Description |
| ---- | ----------- |
| source | *\`\`0[]*<br> |
| conversion | *System.Func{\`\`0,<T>}*<br> |
| break | *System.Func{\`\`0,System.Boolean}*<br> |
| continue | *System.Func{\`\`0,System.Boolean}*<br> |

#### Returns



### ReverseSelect\`\`2(source, conversion)

Reverse Select an Array

#### Type Parameters

- TBase - 
- TResult - 

| Name | Description |
| ---- | ----------- |
| source | *\`\`0[]*<br> |
| conversion | *System.Func{\`\`0,<T>}*<br> |

#### Returns



### SelectPair<T>(inum)

Return an ienumerable of a tuple paired for a successive items

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| inum | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |

#### Returns



### SelectPair\`\`2(inum, method)

IEnumerable Select But using successive pairs

| Name | Description |
| ---- | ----------- |
| inum | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| method | *System.Func{\`\`0,\`\`0,<T>}*<br> |

#### Type Parameters

- T - 
- TD - 

#### Returns



*System.NullReferenceException:* method cannot be null

### SplitFirst<T>(source, predicate)

Find First and split it from the main enumerable

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| source | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| predicate | *System.Func{\`\`0,System.Boolean}*<br> |

#### Returns



### SplitTake<T>(source, count)

Divide an ienumerable into two; first value's size is based on Count.

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| source | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| count | *System.Int32*<br> |

#### Returns




## Ternary

3 boolean type

### False

false

### Neutral

nuetral

### True

true

### KtExtensions.EnumerableExtensions.Venn<T>(AA, BB)

Venn Group Elements of two enumerables based on venn diagram rep

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| AA | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| BB | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |

#### Returns



### KtExtensions.EnumerableExtensions.Venn<T>(ienums, comparer)

Exclusion Inclusion of Elements of two collections

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| ienums | *System.ValueTuple{System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| comparer | *System.Collections.Generic.IEnumerable{\`\`0}}*<br> |

#### Returns



### KtExtensions.EnumerableExtensions.WhereNot<T>(enumerable, other)

Exclude other from the query

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| other | *\`\`0*<br> |

#### Returns



### KtExtensions.EnumerableExtensions.WhereNot<T>(enumerable, others)

Exclude others from the query

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| others | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |

#### Returns



### KtExtensions.EnumerableExtensions.WhereNot<T>(enumerable, predicate)

same Linq -Where but the predicate is negated

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| predicate | *System.Predicate{\`\`0}*<br> |

#### Returns




## EqualityExtensions

Collection of methods for equality purposes

### ChainHashCode<T>(hash, other, multiplier)

Chain the hashcode of the new item to the previous

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| hash | *System.Int32*<br>initial hash |
| other | *\`\`0*<br>other item |
| multiplier | *System.Int32*<br> |

#### Returns



### ChainHashCode<T>(hash, other)

Chain the hashcode of the new item to the previous

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| hash | *System.Int32*<br>initial hash |
| other | *\`\`0*<br>other item |

#### Returns



### ChainHashCode<T>(hash, other)

Chain the hashcode of the new item to the previous

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| hash | *System.Int32*<br>initial hash |
| other | *\`\`0[]*<br>other item |

#### Returns



### ChainHashCode<T>(hash, other)

Chain the hashcode of the new item to the previous

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| hash | *System.Int32*<br>initial hash |
| other | *System.Collections.Generic.IEnumerable{\`\`0}*<br>other item |

#### Returns



### DefaultEquals<T>(a, b)

Shortened <a href="#system.collections.generic.equalitycomparer\`1.default">System.Collections.Generic.EqualityComparer\`1.Default</a>.Equals

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| a | *\`\`0*<br> |
| b | *\`\`0*<br> |

#### Returns



### EqualsObject<T>(a, obj, final)

Test if an element of type T is equal to an object

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| a | *\`\`0*<br> |
| obj | *System.Object*<br> |
| final | *System.Func{\`\`0,System.Boolean}*<br> |

#### Returns



### GetHashCodeOfArray<T>(array)

Determine the hashcode of an array using <a href="#equalityextensions.chainhashcode<T>(system.int32,\`\`0)">EqualityExtensions.ChainHashCode<T>(System.Int32,\`\`0)</a> method

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| array | *\`\`0[]*<br> |

#### Returns



### GetHashCodeOfEnumerable<T>(array)

Determine the hashcode of an enumerable using <a href="#equalityextensions.chainhashcode<T>(system.int32,\`\`0)">EqualityExtensions.ChainHashCode<T>(System.Int32,\`\`0)</a> method

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| array | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |

#### Returns



### TestNullBeforeEquals<T>(a, b, final)

Test for null before doing the final equality check of final

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| a | *\`\`0*<br> |
| b | *\`\`0*<br> |
| final | *System.Boolean*<br> |

#### Returns



### TestNullBeforeEquals<T>(a, b, final)

Test for null before doing the final equality check of final

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| a | *\`\`0*<br> |
| b | *\`\`0*<br> |
| final | *System.Func{\`\`0,System.Boolean}*<br> |

#### Returns



### TestNullBeforeEquals<T>(a, b, final)

Test for null before doing the final equality check of final

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| a | *\`\`0*<br> |
| b | *\`\`0*<br> |
| final | *System.Func{System.Boolean}*<br> |

#### Returns




## FilePathExtensions

Extensions for System.IO.File and System.IO.Path

### CanReadFile(filePath)

Check if a file can be opened

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br> |

### CopyToUniqueName(source, filePathDestination)

extension of File.Copy where destination name will be made unique using <a href="#filepathextensions.getuniquefilepath(system.string)">FilePathExtensions.GetUniqueFilePath(System.String)</a>

| Name | Description |
| ---- | ----------- |
| source | *System.String*<br> |
| filePathDestination | *System.String*<br> |

#### Returns



### GetUniqueFilePath(filepath)

Make file path unique

| Name | Description |
| ---- | ----------- |
| filepath | *System.String*<br> |

#### Returns




## GenericExtensions

Extensions for generic types

### IsNull<T>(value)

Check if a generic value of type T is null Reference: McGivern, D. (2011,Febuary 10) C#: Alternative to GenericType == null [Online forum comment].Message to posted to https://stackoverflow.com/questions/565564/c-alternative-to-generictype-null
 modification was done by using IsNullable() Method 
#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| value | *\`\`0*<br> |

#### Returns



### MakeArrayFor<T>(val, times)

Create an Array using the value with "times" size

| Name | Description |
| ---- | ----------- |
| val | *\`\`0*<br> |
| times | *System.Int32*<br>size of the array |

#### Type Parameters

- T - 

#### Returns



### MakeListFor<T>(val, times)

Create a List using the value with "times" size

| Name | Description |
| ---- | ----------- |
| val | *\`\`0*<br> |
| times | *System.Int32*<br>size of the list |

#### Type Parameters

- T - 

#### Returns




## ListExtensions

List Extensions

### Clone<T>(listToClone)

Deep Clone a List

| Name | Description |
| ---- | ----------- |
| listToClone | *System.Collections.Generic.List{\`\`0}*<br> |

#### Type Parameters

- T - 

#### Returns



### FirstPair<T>(listToLoop, test)

Determine the first pair in list that passed the test

| Name | Description |
| ---- | ----------- |
| listToLoop | *System.Collections.Generic.List{\`\`0}*<br> |
| test | *System.Func{\`\`0,\`\`0,System.Boolean}*<br> |

#### Type Parameters

- T - 

#### Returns

if fails it returns null

### FoundAt<T>(list, item, comparer)

Find the Element and return its index

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.List{\`\`0}*<br> |
| item | *\`\`0*<br> |
| comparer | *System.Collections.Generic.IEqualityComparer{\`\`0}*<br> |

#### Returns



### FoundAt<T>(list, item)

Find the Element and return its index using the Default Equality Comparer

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.List{\`\`0}*<br> |
| item | *\`\`0*<br> |

#### Returns



### IndexedForEach<T>(list, action)

Run for loop using action which takes in <a href="#system.int32">System.Int32</a> index and the item of T

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.List{\`\`0}*<br> |
| action | *System.Action{\`\`0,System.Int32}*<br>is null, the method will not run |

### LoopTwoEach<T>(null, listToLoop, action)

Loop through a List using the two consecutive elements

| Name | Description |
| ---- | ----------- |
|  | *System.Collections.Generic.List{\`\`0}*<br> |
| listToLoop | *System.Action{\`\`0,\`\`0}*<br>The list for looping, count must be beyond 2 |
| action | *Unknown type*<br> |

#### Type Parameters

- T - 

### Swap<T>(list, index1, index2)

swap elements of a List

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.List{\`\`0}*<br> |
| index1 | *System.Int32*<br>index of row 1 |
| index2 | *System.Int32*<br>index of row 2 |

#### Type Parameters

- T - 

#### Returns




## MethodShortcuts

Improved Action methods

### BoolAction(condition, ifTrue, ifFalse)

Runs based on a the condition of condition, runs ifTrue if condition is true and runs ifFalse if condition is false

| Name | Description |
| ---- | ----------- |
| condition | *System.Boolean*<br> |
| ifTrue | *System.Action*<br> |
| ifFalse | *System.Action*<br> |

### Recursion<T>(func)

Inception type of function. create a value null, assign a value

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| func | *System.Func{System.Func{\`\`0},\`\`0}*<br> |

#### Returns



### SeedProcess\`\`2(seed, result)

Chainable initial values to func

#### Type Parameters

- Tseed - 
- Tresult - 

| Name | Description |
| ---- | ----------- |
| seed | *System.Func{\`\`0}*<br> |
| result | *System.Func{\`\`0,<T>}*<br> |

#### Returns



### SeedProcess\`\`3(seed1, seed2, result)

Chainable initial values to func

#### Type Parameters

- Tseed1 - 
- Tseed2 - 
- Tresult - 

| Name | Description |
| ---- | ----------- |
| seed1 | *System.Func{\`\`0}*<br> |
| seed2 | *System.Func{<T>}*<br> |
| result | *System.Func{\`\`0,<T>,\`\`2}*<br> |

#### Returns



### SeedProcess\`\`3(seed, result)

Chainable initial values to func

#### Type Parameters

- Tseed1 - 
- Tseed2 - 
- Tresult - 

| Name | Description |
| ---- | ----------- |
| seed | *System.Func{System.ValueTuple{\`\`0,<T>}}*<br> |
| result | *System.Func{\`\`0,<T>,\`\`2}*<br> |

#### Returns



### SeedProcess\`\`4(seed1, seed2, seed3, result)

Chainable initial values to func

#### Type Parameters

- Tseed1 - 
- Tseed2 - 
- Tseed3 - 
- Tresult - 

| Name | Description |
| ---- | ----------- |
| seed1 | *System.Func{\`\`0}*<br> |
| seed2 | *System.Func{<T>}*<br> |
| seed3 | *System.Func{\`\`2}*<br> |
| result | *System.Func{\`\`0,<T>,\`\`2,\`\`3}*<br> |

#### Returns



### SeedProcess\`\`4(seed, result)

Chainable initial values to func: Tuple of 3

#### Type Parameters

- Tseed1 - 
- Tseed2 - 
- Tseed3 - 
- Tresult - 

| Name | Description |
| ---- | ----------- |
| seed | *System.Func{System.ValueTuple{\`\`0,<T>,\`\`2}}*<br> |
| result | *System.Func{\`\`0,<T>,\`\`2,\`\`3}*<br> |

#### Returns



### SeedProcess\`\`5(seed1, seed2, seed3, seed4, result)

Chainable initial values to func

#### Type Parameters

- Tseed1 - 
- Tseed2 - 
- Tseed3 - 
- Tseed4 - 
- Tresult - 

| Name | Description |
| ---- | ----------- |
| seed1 | *System.Func{\`\`0}*<br> |
| seed2 | *System.Func{<T>}*<br> |
| seed3 | *System.Func{\`\`2}*<br> |
| seed4 | *System.Func{\`\`3}*<br> |
| result | *System.Func{\`\`0,<T>,\`\`2,\`\`3,\`\`4}*<br> |

#### Returns



### SeedProcess\`\`5(seed, result)

Chainable initial values to func: Tuple of 4

#### Type Parameters

- Tseed1 - 
- Tseed2 - 
- Tseed3 - 
- Tseed4 - 
- Tresult - 

| Name | Description |
| ---- | ----------- |
| seed | *System.Func{System.ValueTuple{\`\`0,<T>,\`\`2,\`\`3}}*<br> |
| result | *System.Func{\`\`0,<T>,\`\`2,\`\`3,\`\`4}*<br> |

#### Returns



### SeedProcess\`\`5(seed1, seed2, result)

Chainable initial values to func

#### Type Parameters

- Tseed1 - 
- Tseed2 - 
- Tseed3 - 
- Tseed4 - 
- Tresult - 

| Name | Description |
| ---- | ----------- |
| seed1 | *System.Func{System.ValueTuple{\`\`0,<T>}}*<br> |
| seed2 | *System.Func{System.ValueTuple{\`\`2,\`\`3}}*<br> |
| result | *System.Func{\`\`0,<T>,\`\`2,\`\`3,\`\`4}*<br> |

#### Returns



### SeedProcess\`\`6(seed1, seed2, seed3, seed4, seed5, result)

Chainable initial values to func: 5 seed elements

#### Type Parameters

- Tseed1 - 
- Tseed2 - 
- Tseed3 - 
- Tseed4 - 
- Tseed5 - 
- Tresult - 

| Name | Description |
| ---- | ----------- |
| seed1 | *System.Func{\`\`0}*<br> |
| seed2 | *System.Func{<T>}*<br> |
| seed3 | *System.Func{\`\`2}*<br> |
| seed4 | *System.Func{\`\`3}*<br> |
| seed5 | *System.Func{\`\`4}*<br> |
| result | *System.Func{\`\`0,<T>,\`\`2,\`\`3,\`\`4,\`\`5}*<br> |

#### Returns



### SeedProcess\`\`6(seed, result)

Chainable initial values to func: Tuple of 5

#### Type Parameters

- Tseed1 - 
- Tseed2 - 
- Tseed3 - 
- Tseed4 - 
- Tseed5 - 
- Tresult - 

| Name | Description |
| ---- | ----------- |
| seed | *System.Func{System.ValueTuple{\`\`0,<T>,\`\`2,\`\`3,\`\`4}}*<br> |
| result | *System.Func{\`\`0,<T>,\`\`2,\`\`3,\`\`4,\`\`5}*<br> |

#### Returns




## NumberDisplayExtensions

Extensions for converting numeric values to proper string format

### ToExp(val)

Convert a number into string exponential form string

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br> |

#### Returns




## NumericExtensions

Numeric Extensions

### Atan3(y, x)

Return the angle in degrees

| Name | Description |
| ---- | ----------- |
| y | *System.Double*<br>numerator of the tangent function |
| x | *System.Double*<br>denominator of the tangent function |

#### Returns



### Base10Of1stSignificantFigure(val)

get the decimal place of first significant figure

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br> |

#### Returns



### CompareTo(values)

(v1,v2) => v1.CompareTo(v2)

| Name | Description |
| ---- | ----------- |
| values | *System.ValueTuple{System.Double,System.Double}*<br> |

#### Returns



### CycleWithin(val1, val2, val3)

Used for looping through circular sequence

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br>The Number that loops |
| val2 | *System.Double*<br>The Begining of the loop |
| val3 | *System.Double*<br>The end of the loop |

#### Returns

Looped equivalent of val1

### CycleWithin(val1, val2, val3)

Used for looping through circular sequence

| Name | Description |
| ---- | ----------- |
| val1 | *System.Int32*<br>The Number that loops |
| val2 | *System.Int32*<br>The Begining of the loop |
| val3 | *System.Int32*<br>The end of the loop |

#### Returns

Looped equivalent of val1

### Exp(val1, val2)

multiply a number with 10 raised to ____

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Double*<br>Power of th multiplyier number "10" |

#### Returns



### Exp(val1, val2)

multiply a number with 10 raised to ____

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Int32*<br>Power of th multiplyier number "10" |

#### Returns



### GetPotentialNumber(val)

Check if a string can potentially be converted into number

| Name | Description |
| ---- | ----------- |
| val | *System.String*<br> |

#### Returns



### HasDecimal(val)

Return if a double value has floating values

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br> |

#### Returns



### HasDecimal(val)

Check if string is a number and has float values.

| Name | Description |
| ---- | ----------- |
| val | *System.String*<br>string to check |

#### Returns



### IntToArray(val)

Convert an integer to an array of single digits

| Name | Description |
| ---- | ----------- |
| val | *System.Int64*<br> |

#### Returns



### InvalidNumber(val)

check if a number is infinity or NaN

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br>the value to be tested |

#### Returns

Boolean value

### IsBetween(val1, val2, val3)

Test if a number is inside but should not be on the limits

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Double*<br>Limit 1 |
| val3 | *System.Double*<br>Limit 2 |

#### Returns



### IsBetween(val1, val2, val3)

Test if a number is inside but should not be on the limits

| Name | Description |
| ---- | ----------- |
| val1 | *System.Int32*<br> |
| val2 | *System.Int32*<br>Limit 1 |
| val3 | *System.Int32*<br>Limit 2 |

#### Returns



### IsBetween(val1, val2, val3)

Test if a number is inside but should not be on the limits

| Name | Description |
| ---- | ----------- |
| val1 | *System.Int64*<br> |
| val2 | *System.Int64*<br>Limit 1 |
| val3 | *System.Int64*<br>Limit 2 |

#### Returns



### IsEven(value)

Determine if an integer is Even

| Name | Description |
| ---- | ----------- |
| value | *System.Int32*<br> |

#### Returns



### IsNumeric(val)

Determine if a string can be converted into a number, Similar VB.net IsNumeric Function

| Name | Description |
| ---- | ----------- |
| val | *System.String*<br>The string to be tested |

#### Returns

Boolean Value

### IsWithin(val1, val2, val3)

Test if a number is inside or exactly on the limits

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Double*<br>Limit 1 |
| val3 | *System.Double*<br>Limit 2 |

#### Returns



### IsWithin(val1, limits)

Test if a number is inside or exactly on the limits

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| limits | *System.ValueTuple{System.Double,System.Double}*<br> |

#### Returns



### IsWithin(val1, val2, val3)

Test if a number is inside or exactly on the limits

| Name | Description |
| ---- | ----------- |
| val1 | *System.Int32*<br> |
| val2 | *System.Int32*<br>Limit 1 |
| val3 | *System.Int32*<br>Limit 2 |

#### Returns



### IsWithin(val1, limits)

Test if a number is inside or exactly on the limits

| Name | Description |
| ---- | ----------- |
| val1 | *System.Int32*<br> |
| limits | *System.ValueTuple{System.Int32,System.Int32}*<br> |

#### Returns



### LimitWithin(val1, val2, val3)

Make a value stay within the limits (Including the limits themselves)

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Double*<br>Limit 1 |
| val3 | *System.Double*<br>Limit |

#### Returns



### LimitWithin(val1, val2, val3)

Make a value stay within the limits (Including the limits themselves)

| Name | Description |
| ---- | ----------- |
| val1 | *System.Int32*<br> |
| val2 | *System.Int32*<br>Limit 1 |
| val3 | *System.Int32*<br>Limit |

#### Returns



### LimitWithin(val1, val2, val3)

Make a value stay within the limits (Including the limits themselves)

| Name | Description |
| ---- | ----------- |
| val1 | *System.Int64*<br> |
| val2 | *System.Int64*<br>Limit 1 |
| val3 | *System.Int64*<br>Limit |

#### Returns



### MinMax(val1, val2)

determine the min or max of two doubles

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Double*<br> |

#### Returns



### MinMax(val1, val2)

determine the min or max of two integers

| Name | Description |
| ---- | ----------- |
| val1 | *System.Int32*<br> |
| val2 | *System.Int32*<br> |

#### Returns



### NearEqual(val1, val2, accuracy)

Check if a number is Approximately Equal to the other

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Double*<br> |
| accuracy | *System.Int32*<br> |

#### Returns



### NearZero(val, accuracy)

Determine if a double number is almost equal to zero

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br> |
| accuracy | *System.Int32*<br>accuracy to the n'th degree |

#### Returns



### NoFloat(val, precision)

Check if a double value is an integer

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br> |
| precision | *System.Int32*<br> |

#### Returns




## NumberSign

Numeric Enumeration

### Negative

Less that 0

### Neutral

Exactly Zero

### Positive

Greater than 0

### KtExtensions.NumericExtensions.RaiseTo(val1, val2)

Acts like an exponent/power

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Double*<br>exponent |

#### Returns



### KtExtensions.NumericExtensions.RaiseTo(val1, val2)

Acts like an exponent/power

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Int32*<br>exponent |

#### Returns



### KtExtensions.NumericExtensions.RaiseTo(val1, val2)

Acts like an exponent/power

| Name | Description |
| ---- | ----------- |
| val1 | *System.Int32*<br> |
| val2 | *System.Double*<br>exponent |

#### Returns



### KtExtensions.NumericExtensions.RaiseTo(val1, val2)

Acts like an exponent/power

| Name | Description |
| ---- | ----------- |
| val1 | *System.Int32*<br> |
| val2 | *System.Int32*<br>exponent |

#### Returns



### KtExtensions.NumericExtensions.Roundby(val1, val2)

Round for every interval

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Double*<br>interval |

#### Returns



### KtExtensions.NumericExtensions.Roundby(val1, val2)

Round for every interval

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Int32*<br>interval |

#### Returns



### KtExtensions.NumericExtensions.RoundDownby(val1, val2)

Round down for every interval

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Double*<br>interval |

#### Returns



### KtExtensions.NumericExtensions.RoundDownby(val1, val2)

Round down for every interval

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Int32*<br>interval |

#### Returns



### KtExtensions.NumericExtensions.RoundUpby(val1, val2)

Roundup for every interval

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Double*<br>interval |

#### Returns



### KtExtensions.NumericExtensions.RoundUpby(val1, val2)

Roundup for every interval

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br> |
| val2 | *System.Int32*<br>interval |

#### Returns



### KtExtensions.NumericExtensions.ScientificNotation(val)

Return the scientific notation

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br>todo: describe val parameter on ScientificNotation |

#### Returns

return a tuple of significant figure in 1's and the base 10 exponent

### KtExtensions.NumericExtensions.Sign(num, accuracy)

Determine the sign of a number

| Name | Description |
| ---- | ----------- |
| num | *System.Double*<br> |
| accuracy | *System.Int32*<br> |

#### Returns



### KtExtensions.NumericExtensions.Sign(num)

Determine the sign of a number

| Name | Description |
| ---- | ----------- |
| num | *System.Int32*<br> |

#### Returns



### KtExtensions.NumericExtensions.SmartRoundActual(val, digits)

Round the value based on the repeated 999's and 000's

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br> |
| digits | *System.Int64[]*<br> |

#### Returns



### KtExtensions.NumericExtensions.SmartRoundSignificantValue(val, digits)

Round The number by finding the first repeated digits from the number;

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br> |
| digits | *System.Int64[]*<br>digits that are repeated |

#### Returns



### KtExtensions.NumericExtensions.SmartToString(val)

Desirable tostring of a double data type

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br> |

#### Returns



### KtExtensions.NumericExtensions.Store15DecimalsToArray(val)

Make 15 decimals to array

| Name | Description |
| ---- | ----------- |
| val | *System.Double*<br> |

#### Returns



### KtExtensions.NumericExtensions.ToDouble(val)

Convert a string to a number, if the string is not numeric then the return value will be zero

| Name | Description |
| ---- | ----------- |
| val | *System.String*<br> |

#### Returns




## Partition\`2

Grouping of Ienumerable

#### Type Parameters

- TKey - 
- TValue - 

### Constructor

base Constructor

### Constructor(info, context)

Constructor

| Name | Description |
| ---- | ----------- |
| info | *System.Runtime.Serialization.SerializationInfo*<br> |
| context | *System.Runtime.Serialization.StreamingContext*<br> |

### Add(key, value)

Add Individual Element

| Name | Description |
| ---- | ----------- |
| key | *\`0*<br> |
| value | *\`1*<br> |

### Add(key, value)

Add a partition

| Name | Description |
| ---- | ----------- |
| key | *\`0*<br> |
| value | *System.Collections.Generic.List{\`1}*<br> |

### Item(\`0)

Create Partition

| Name | Description |
| ---- | ----------- |
| key | *\`0*<br> |

#### Returns



### Remove(key)

Remove a partition

| Name | Description |
| ---- | ----------- |
| key | *\`0*<br> |


## ReflectionExtensions

Reflection extensions

### GetCascadedPropertyValue(o, name)

Get the property value cascaded to its subproperties

| Name | Description |
| ---- | ----------- |
| o | *System.Object*<br> |
| name | *System.String*<br> |

### GetCascadedPropertyValue(o, pNames)

Get the property value cascaded to its subproperties

| Name | Description |
| ---- | ----------- |
| o | *System.Object*<br> |
| pNames | *System.String[]*<br> |

#### Returns



### GetPropertyValue(o, pName)

The the value of the runtime property of name pName

| Name | Description |
| ---- | ----------- |
| o | *System.Object*<br> |
| pName | *System.String*<br> |

#### Returns



*System.ArgumentNullException:* 

### GetPropertyValue<T>(obj, propertyName)

Get the value of Property and cast it to it's proper type

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br> |
| propertyName | *System.String*<br> |

#### Returns



### GetPropertyValues(obj)

Search all property names, get their values, and store them into a dictionary of string/object generic type

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br> |

#### Returns



### GetPropertyValues<T>(objs)

Search all property names, get their values, and store them into a dictionary of string/object generic type

| Name | Description |
| ---- | ----------- |
| objs | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |

#### Returns



### PropertyValueString(o, pName)

Get value of object

| Name | Description |
| ---- | ----------- |
| o | *System.Object*<br> |
| pName | *System.String*<br> |

#### Returns




## StringManipulation

String extensions

### AppendNewLine(sb)

Append new line to the string builder

| Name | Description |
| ---- | ----------- |
| sb | *System.Text.StringBuilder*<br> |

#### Returns



### AppendThenNewLine(sb, str)

Append A string then add new line

| Name | Description |
| ---- | ----------- |
| sb | *System.Text.StringBuilder*<br> |
| str | *System.String*<br> |

#### Returns



### AppendWhen(sb, str, predicate)

Append A string then when

| Name | Description |
| ---- | ----------- |
| sb | *System.Text.StringBuilder*<br> |
| str | *System.String*<br> |
| predicate | *System.Func{System.Boolean}*<br> |

#### Returns



### BuildString<T>(enumerable, separator, enclosure)

Concatenate all the element <a href="#system.object.tostring">System.Object.ToString</a> value of an enumerable

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| separator | *System.String*<br>String separating each string |
| enclosure | *System.ValueTuple{System.String,System.String}*<br>strings enclosing the element string |

#### Returns



### BuildString<T>(enumerable, separator)

Concatenate all the element <a href="#system.object.tostring">System.Object.ToString</a> value of an enumerable

#### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| separator | *System.String*<br>String separating each string |

#### Returns



### FirstCharacterToLower(str)

Make First Letter of a string into lower character

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |

#### Returns



### FirstCharacterToUpper(str)

Make First Letter of a string into upper character

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |

#### Returns



### GuardClausedEquals(str1, str2, stringComparison)

Guard Claused Equals w/ string comparison

| Name | Description |
| ---- | ----------- |
| str1 | *System.String*<br> |
| str2 | *System.String*<br> |
| stringComparison | *System.StringComparison*<br> |

#### Returns



### GuardClausedEquals(str1, str2)

Guard Claused Equals

| Name | Description |
| ---- | ----------- |
| str1 | *System.String*<br> |
| str2 | *System.String*<br> |

#### Returns



### Has(this, possibles)

Determine if a character is inside a list of characters

| Name | Description |
| ---- | ----------- |
| this | *System.String*<br> |
| possibles | *System.Char[]*<br> |

#### Returns



### Has(this, possibles)

Determine if a character is inside a list of strings

| Name | Description |
| ---- | ----------- |
| this | *System.String*<br> |
| possibles | *System.String[]*<br> |

#### Returns



### IsNullOrEmpty(str)

Similar to <a href="#system.string.isnullorempty(system.string)">System.String.IsNullOrEmpty(System.String)</a>

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |

#### Returns



### MakeUniqueFrom(str, strs, maxLength)

Check if string is a duplicate and create new numbered string

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |
| strs | *System.Collections.Generic.IEnumerable{System.String}*<br> |
| maxLength | *System.Int32*<br> |

#### Returns



### MakeUniqueFrom(str, strs)

Check if string is a duplicate and create new numbered string

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |
| strs | *System.Collections.Generic.IEnumerable{System.String}*<br> |

#### Returns



### RemoveLastChar(str)

Remove the last letter of the string

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |

#### Returns



### RemoveVowels(str)

Remove Vowels from strings

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |

#### Returns



### RepeatString(str, count)

Concatenate a repeat string at a number of times

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br>the string to be repeated |
| count | *System.Int32*<br>number of times to repeat |

#### Returns



### SmartAppend(str, strToAppend)

Be able identify if it is good to append a text to the main text 

if str is null or empty then an empty text is returned

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |
| strToAppend | *System.String*<br> |

### SmartConcat(str1, str2, filler)

Concat Two strings with a filler

| Name | Description |
| ---- | ----------- |
| str1 | *System.String*<br> |
| str2 | *System.String*<br> |
| filler | *System.String*<br> |

#### Returns



### SmartConcat(str, toConcat, filler)

Concat strings with filler

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |
| toConcat | *System.String[]*<br> |
| filler | *System.String*<br> |

#### Returns



### SmartPrepend(str, strToPrepend)

Be able identify if it is good to prepend a text to the main text 

if str is null or empty then an empty text is returned

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |
| strToPrepend | *System.String*<br> |

### SplitTextAndNumber(text)

Separate String and Number, example "text (1)" the text and the number will be extracted

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br> |

#### Returns

text and a number, "text (1)" return "text " and "1"

### ToWords(number)

Convert integers to words

| Name | Description |
| ---- | ----------- |
| number | *System.Int32*<br> |

#### Returns




## TypesExtensions

Extensions for type

### GetTypeHierarchy(type)

Get all type derivation Reference: KallDrexx (2011, June 21). How can I use reflection to return all classes subclassing from a generic, without giving a specific generic type [Online forum comment]. Message posted to https://stackoverflow.com/questions/6426949/how-can-i-use-reflection-to-return-all-classes-subclassing-from-a-generic-witho/6427201#6427201

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br> |

#### Returns



### IsDerivedFromOpenGenericType(type, openGenericType)

Determine if a type is derived from open generic type Reference: KallDrexx (2011, June 21). How can I use reflection to return all classes subclassing from a generic, without giving a specific generic type [Online forum comment]. Message posted to https://stackoverflow.com/questions/6426949/how-can-i-use-reflection-to-return-all-classes-subclassing-from-a-generic-witho/6427201#6427201

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br> |
| openGenericType | *System.Type*<br> |

#### Returns



*System.ArgumentNullException:* 

*System.ArgumentException:* 

### IsNullable(type)

Determine if a generic param is a Nullable type Reference: Traub, D. (2011, March 3). Determine if a generic param is a Nullable type [Online forum comment]. Message posted to https://stackoverflow.com/questions/5181494/determine-if-a-generic-param-is-a-nullable-type

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br> |

#### Returns


