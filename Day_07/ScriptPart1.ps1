$input =  Get-Content .\input.txt
$input = $input.Split(",")

$horizontalPosition = New-Object Collections.Generic.List[Int]

#from string list -> to int
$input | ForEach-Object {$horizontalPosition.Add($_ -as [int])}

$max = ($horizontalPosition | Measure-Object -Maximum).Maximum

$minCount =  20000000000
1 .. $max | ForEach-Object { 
    $temp = $_
    $sum = 0
    $horizontalPosition | ForEach-Object {  
        $sum += [Math]::Abs($_ - $temp)
    }
    $minCount = [Math]::Min($minCount, $sum)
}

Write-Output $minCount


