# EP01: Aspire 대시보드의 모든 것

Link: [https://aka.ms/aspire-in-the-belly/ep01](https://aka.ms/aspire-in-the-belly/ep01)

본격적으로 .NET Aspire 앱을 시작해 볼까요?

이번 세션에서는 .NET Aspire 스타터 프로젝트를 이용해서 앱이 어떻게 작동하는지 한 번 알아보겠습니다.

.NET Aspire의 가장 큰 특징 중 하나는 바로 대시보드 기능입니다.

클라우드네이티브 앱을 로컬에서 개발하면서 애플리케이션 사이 데이터들이 어떻게 흘러가는지 한눈에 보기 힘들었는데, OpenTelemetry 기능을 활용한 대시보드를 보면 데이터가 어떻게 흘러가는지 한눈에 볼 수 있습니다.

.NET Aspire 스타터 프로젝트를 이용해 대시보드가 어떤 기능을 하는지 한 번 알아볼까요?

🔗 링크: https://aka.ms/aspire-in-the-belly
🎙️ 진행: 김진석 (Microsoft MVP), 박구삼 (Microsoft MVP)

# Source Code 설명

AspireEp01.sln 솔루션을 열어 Aspire의 전체적인 구조를 파악할 수 있는 프로젝트입니다.
.NET Aspire 시작 어플리케이션 프로젝트로 생성한 내용과 거의 다르지 않습니다.

- AspireEp01.ApiService : 웹 백엔드 프로젝트
- AspireEp01.AppHost : Aspire 대시보드 프로젝트
- AspireEp01.ServiceDefaults : OTEL을 쉽게 구현하기 위한 서비스 프로젝트
- AspireEp01.WEb : 웹 프론트엔드 프로젝트

**참고사항**   
http 구성의 경우 launchSettings.json파일에 ASPIRE_ALLOW_UNSECURED_TRANSPORT설정을 해주어야 합니다.   
[Allow unsecure transport in .NET Aspire](https://learn.microsoft.com/ko-kr/dotnet/aspire/troubleshooting/allow-unsecure-transport?tabs=windows&WT.mc_id=MVP_307888) 를 참고하세요.