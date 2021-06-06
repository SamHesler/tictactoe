
#--- Insert your Webhook Connector URI
$uri = 'https://redhawks.webhook.office.com/webhookb2/ee44375a-b8dd-4552-801a-77de5d2e24cc@bc10e052-b01c-4849-9967-ee7ec74fc9d8/IncomingWebhook/1d7384c8ca3c46deb53cd78a534c0f11/03504a9b-1168-4275-9aab-e70f13ff3492'
#--- Insert a public URI to the Image you want to attach to the Message
$image = 'https://thomas.geens.be/wp-content/uploads/2019/02/favicon-1.gif'

# Create a Generic List holding the Activities
$Sections = New-Object 'System.Collections.Generic.List[System.Object]'

# Insert 3 Different Activities as an example 
for ($i = 1; $i -lt 4; $i++) {
    # Generate Activity Number 1-3
    $Section = @{
        activityTitle = "Section$i.Activitytitle"
        activitySubTitle = "Section$i.ActivitySubTitle"
        activityText = "Section$i.ActivityText"
        activityImage = $image
        facts = @(
                    @{
                        name = "Section$i.Fact1.Name"
                        value = "Section$i.Fact2.Value"
                    },
                    @{
                        name = "Section$i.Fact2.Name"
                        value = "Section$i.Fact.2Value"
                    }
                )  
    }
    # Add Generated Activity Number 1-3 To Sections
    $Sections.Add($Section)
}

# Create the Message holding the Activities inside
# Convert Message Generic List Object to a JSON Array Object
$body = ConvertTo-Json -Depth 8 @{
    title = 'Title'
    text = 'Text'
    summary = 'Summary'
    sections = $Sections
    potentialAction =   @(
                            @{
                                '@context'  = 'http://schema.org'
                                '@type' = 'ViewAction'
                                name = 'Google'
                                target = @("https://www.google.be")
                            },
                            @{
                                '@context'  = 'http://schema.org'
                                '@type' = 'ViewAction'
                                name = 'Wikipedia'
                                target = @("https://www.wikipedia.com")
                            }
                        ) 
}

# Post the JSON Array Object to the Webhook Connector URI
Invoke-RestMethod -Uri $uri -Method Post -Body $body -ContentType 'application/json'