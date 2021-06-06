


write-Host `n '             DOUGs Team
***Script for Regression testing***'`n -Foregroundcolor yellow

while(1)
{

write-Host "Select any one below options:"`n -ForegroundColor Magenta
 
Write-host '1. BUILD'`n -ForegroundColor DarkYellow
Write-host '2. BUILD & RUN'`n -ForegroundColor DarkYellow
write-host '3. MOVE LOGS TO CLOUD'`n -ForegroundColor DarkYellow
write-host '4. SEND MESSAGE TO TEAMS CHANNEL'`n -ForegroundColor DarkYellow
write-host '5. Exit'`n -ForegroundColor DarkYellow

$Option = read-host "Enter your option"

If($Option -eq 1){Invoke-Expression 'C:\Users\PRATHYUSHA\Desktop\newonne\msbuild.ps1'}
elseif($Option -eq 2){Invoke-Expression 'C:\Users\PRATHYUSHA\Desktop\newonne\bld.ps1'}
elseif($Option -eq 3){Invoke-Expression 'C:\Users\PRATHYUSHA\Desktop\newonne\move2Cloud.ps1'}
elseif($Option -eq 4){Invoke-Expression 'C:\Users\PRATHYUSHA\Desktop\newonne\teamsAlert.ps1'}
elseif($Option -eq 5){
Write-Host `n "You have successfully exited from the script"  -ForegroundColor Green  
sleep -seconds 5
exit
}
else{
    write-Host "Entered option is wrong.....Going to exit from console in 5 seconds"`n -ForegroundColor red
    sleep -seconds 5 
    Exit
    }


   
}#while