write-Host '*****Script for building and Running test cases*****'`n -Foregroundcolor Magenta
#dependencies
 if(!(Get-InstalledModule | Where-Object {$_.Name -like "buildut*"})){
 Install-Module BuildUtils -Scope CurrentUser -Force}
 $msbuildLocation = Get-LatestMsbuildLocation
 set-alias msb $msbuildLocation


 ################BUILD STARTED#######################################

 $path="C:\Users\PRATHYUSHA\source\repos\"


msb "C:\Users\PRATHYUSHA\source\repos\tictactoe\TicTacToe.sln"| Out-File $path\failedbuil.log


#"My-Script-" + (date_time()) + ".log"

$swap=0;

$log = get-content $path\"failedbuil.log"

foreach ($line in $log)
 { 
    if ($line -like "*error CS*") 
    {
               $line | out-file -FilePath "$path\failbuildmsg" -Append
               #$line | out-file -FilePath $path\"failbuildmsg_sort"+$LogTime+".log" -Append

               $swap=1;

    }
}
 

  if($swap -ceq 1)
   {
    Write-Host "Build FAILED" -ForegroundColor Red
     Write-Host "Sending............. BUILD FAILD to mail, Please enter email" -ForegroundColor yellow
     
     Invoke-Expression 'C:\Users\PRATHYUSHA\Desktop\newonne\bldemail.ps1'
     }

     else
     {
     Invoke-Expression 'C:\Users\PRATHYUSHA\Desktop\newonne\tstrn.ps1'
      Write-Host "MAIL SENT TO TEAM" -ForegroundColor green
     }
