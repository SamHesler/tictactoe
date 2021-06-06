Write-Host "Running test cases" -ForegroundColor Green

$ErrorActionPreference="SilentlyContinue"
Stop-Transcript | out-null
$ErrorActionPreference = "Continue"
$path="C:\Users\PRATHYUSHA\source\repos\$(gc env:computername).log"
if($path)
{
#color
$host.PrivateData.ErrorBackgroundColor='blue'

Remove-Item $path
Start-Transcript -path "C:\Users\PRATHYUSHA\source\repos\$(gc env:computername).log" -append 

dotnet test  C:\Users\PRATHYUSHA\source\repos\tictactoe\TicTacToeTests2\bin\Debug\netcoreapp3.1\TicTacToeTests.dll  --logger:"console;verbosity=detailed" --blame

Stop-Transcript
}

 Invoke-Expression C:\Users\PRATHYUSHA\Desktop\newonne\buildTestSuite.ps1


##################TEST CASES CHECKED#############################################