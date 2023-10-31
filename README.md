# MailAutoConfiguration

## 概要

[Thunderbird:Autoconfiguration](https://wiki.mozilla.org/Thunderbird:Autoconfiguration) のロジックに従って ConfigFileFormat を取得する
ライブラリ及び CLI

## 利用方法

```bash
$ dotnet run --project MailAutoConfigurationCLI example@gmail.com
{
  "EmailProviders": [
    {
      "DisplayName": "Google Mail",
      "DisplayShortName": "GMail",
      "Domains": [
        "gmail.com",
        "googlemail.com",
        "google.com",
        "jazztel.es"
      ],
...
```
