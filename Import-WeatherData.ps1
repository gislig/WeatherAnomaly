$AllVedur = Import-Csv -Path C:\temp\vedur.csv -Delimiter "`t" | Select-Object Stod, Timi, T, FX, F, P


$uri = "https://weatheranomaly.azurewebsites.net/weather"


foreach($vedur in $AllVedur){
    $t = $vedur.TIMI -split " "

    $t = $t[0]+"T"+$t[1] + ".000Z"

    $body = @{
      country= "Iceland"
      fx=($vedur.fx) -replace ",","."
      f=($vedur.f) -replace ",","."
      t=($vedur.t) -replace ",","."
      p=($vedur.p) -replace ",","."
      checkTime=$t
    }
    $json = $body | ConvertTo-Json
    $json
    Invoke-RestMethod -Method Post -Uri $uri -Body $json -ContentType "application/json"
}

