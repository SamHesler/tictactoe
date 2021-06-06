



param(
    [Parameter(Mandatory=$True, Position=0, ValueFromPipeline=$false)]
    [System.String]
    $Address,

    [Parameter(Mandatory=$false, Position=1, ValueFromPipeline=$false)]
    [System.String]
    $subject="BUILD FAILED",

    [Parameter(Mandatory=$false, Position=1, ValueFromPipeline=$false)]
    [System.String]
    $body="ARTIFACT#10321"
)

Begin {
Clear-Host
    }

Process {
# Create an instance Microsoft Outlook
$Outlook = New-Object -ComObject Outlook.Application
$Mail = $Outlook.CreateItem(0)
$Mail.To = "$Address"
$Mail.Subject = $Subject

$bodyContents=get-content ".\source\repos\failbuildmsg.log" | where {$_ -match "error CS*"} | Format-Table -AutoSize | Out-String

$msg = new-object Net.Mail.MailMessage
$MSG.Body="===========================BUILD FAILED======================================== `n`n`n" 
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
               