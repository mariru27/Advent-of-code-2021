
 1..25 | % {if($_ -gt 9) { MD "Day_$_"; NI "Day_$_/part1.cs", "Day_$_/part2.cs"} else { MD "Day_0$_"; NI "Day_0$_/part1.cs", "Day_0$_/part2.cs"}}
 