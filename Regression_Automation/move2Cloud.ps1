Connect-AzAccount
$RGname="mystuff"
$storage_acc="mystuffdisks" 

$context = (Get-AzStorageAccount -ResourceGroupName $RGname -AccountName $storage_acc).context
$sas=New-AzStorageAccountSASToken -Context $context -Service Blob,File,Table,Queue -ResourceType Service,Container,Object -Permission racwdlup


C:\Users\PRATHYUSHA\Desktop\newonne\azcopy_windows_amd64_10.10.0\azcopy.exe copy "C:\Users\PRATHYUSHA\source\repos\RAVITEJAPOOSALA.log" "https://mystuffdisks.blob.core.windows.net/doug/$sas"

Write-Host "log files moved to cloud"-ForegroundColor Green