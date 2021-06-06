#[Parameter(Mandatory=$true,Position=0, ParameterSetName='Name')]
#[String]$Address,

param(
    [Parameter(Mandatory=$True, Position=0, ValueFromPipeline=$false)]
    [System.String]
    $Address,

    [Parameter(Mandatory=$false, Position=1, ValueFromPipeline=$false)]
    [System.String]
    $subject="TEST CASES SUMMARY",

    [Parameter(Mandatory=$false, Position=1, ValueFromPipeline=$false)]
    [System.String]
    $body="TEST RESULT"
)

Begin {
Clear-Host
    }

Process {
$Outlook = New-Object -ComObject Outlook.Application
$Mail = $Outlook.CreateItem(0)
$Mail.To = "$Address"
$Mail.Subject = $Subject
$bodyContents=get-content ".\source\repos\RAVITEJAPOOSALA.log" | where {$_ -match "passed" -or $_ -match "failed"} | Format-Table -AutoSize | Out-String
$msg = new-object Net.Mail.MailMessage
$MSG.Body="===========================BUILD SUCCESSED======================================== `n`n`n" 
$msg.body += $bodyContents
$body=$msg.body 
$Mail.Body =  $Body 
$Mail.Send()
       } # End of Process section
End {
# Section to prevent error message in Outlook
Write-Host "Mail sent Successfully" -ForegroundColor Green
$Outlook.Quit()
[System.Runtime.Interopservices.Marshal]::ReleaseComObject($Outlook)
$Outlook = $null
   } # End of End section!

