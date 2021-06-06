#https://redhawks.webhook.office.com/webhookb2/29d079d1-1bc4-453d-a1f5-8f14e6bfe552@bc10e052-b01c-4849-9967-ee7ec74fc9d8/IncomingWebhook/1d8537349cfb4701af39f976502e78e5/03504a9b-1168-4275-9aab-e70f13ff3492

$JSONBody = [PSCustomObject][Ordered]@{
    "@type"      = "MessageCard"
    "@context"   = "http://schema.org/extensions"
    "summary"    = " Alert !!!"
    "themeColor" = '0078D7'
    "title"      = "TEST SUITS RESULT SENT TO MAIL!"
    "text"       = "There was an email and we should act on it."
}

$TeamMessageBody = ConvertTo-Json $JSONBody -Depth 100

$parameters = @{
    "URI"         = 'https://redhawks.webhook.office.com/webhookb2/29d079d1-1bc4-453d-a1f5-8f14e6bfe552@bc10e052-b01c-4849-9967-ee7ec74fc9d8/IncomingWebhook/1d8537349cfb4701af39f976502e78e5/03504a9b-1168-4275-9aab-e70f13ff3492'
    "Method"      = 'POST'
    "Body"        = $TeamMessageBody
    "ContentType" = 'application/json'
}

$status=Invoke-RestMethod @parameters 
if($status -eq 1){
Write-Host "ALERT SENT TO TEAMS CHANNEL" -ForegroundColor Green}

else{
write-host "ALERT NOT SENT .....CHECK WEEKHOOK LINK" -ForegroundColor Red}