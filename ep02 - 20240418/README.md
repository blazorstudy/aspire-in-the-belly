# EP02: Aspire 컴포넌트 소개

Link: [https://aka.ms/aspire-in-the-belly/ep02](https://aka.ms/aspire-in-the-belly/ep02)

#dotnetaspire #blazor #cloudnative #apireinthebelly

지금까지 대시보드를 살펴봤고 이번에는 컴포넌트를 한 번 붙여봅시다!

이번 세션에서는 .NET Aspire에서 제공하는 여러 컴포넌트중 두 개를 붙여볼 예정입니다. 먼저 가장 널리 쓰이는 메시지 큐 서비스인 RabbitMQ 컴포넌트를 연결해 보겠습니다. 이어서 RabbitMQ와 비슷한 서비스 중 하나인 애저 Storage Queue 서비스 컴포넌트도 한 번 붙여보겠습니다.

평소에 메시지 큐 서비스에 관심이 있거나 .NET Aspire에 기존 사용중인 컴포넌트를 어떻게 연결시킬 수 있는지 궁금하다면 이번 시간을 기대해주세요!

🔗 링크: https://aka.ms/aspire-in-the-belly
🎙️ 진행: 김진석 (Microsoft MVP), 박구삼 (Microsoft MVP)


# Source Code 설명

AspireEp02.sln 솔루션을 열어 Aspire와 RabbitMQ 컴포넌트가 어떻게 연결됐는지를 파악할 수 있는 프로젝트입니다.

기본적으로 [AspireEp01](../ep01%20-%2020240404/README.md)의 구조에서 RabbitMQ 컴포넌트를 갖는 서비스만 추가하였습니다.

- AspireEp02.ApiService
- AspireEp02.AppHost
- AspireEp02.ServiceDefaults
- AspireEp02.Web
- **AspireEp02.RabbitMQService** (추가)

### 참고사항

[AspireEp02.RabbitMQService](./AspireEp02.RabbitMQService/AspireEp02.RabbitMQService.csproj)를 [AspireEp02.AppHost](./AspireEp02.AppHost/AspireEp02.AppHost.csproj)에서 Container로 선언하였기에 이 예제에서는 Docker가 필요합니다.