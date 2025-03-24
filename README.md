# WpfMeetup_250324
![image](https://github.com/user-attachments/assets/d762739a-7934-4fc3-895f-59252a6e5050)

본 자료는 모델(Model), 뷰 모델(ViewModel), 스타일(Styles), 뷰(View) 과정을 중심으로 설명됩니다. 이를 이해하면 전체적인 구조를 쉽게 파악할 수 있습니다.

## 개요

본 프로젝트는 **밋업(Meetup) 자료**로, MVVM(Model-View-ViewModel) 패턴을 기반으로 구성되어 있습니다. 해당 개념을 이해하면, 프로젝트의 흐름을 효과적으로 파악할 수 있습니다.

## 구성 요소

**1. Model (모델)**
- 애플리케이션에서 사용되는 데이터 구조를 정의합니다.
- `MessageModel`은 메시지의 기본 속성(`Text`, `Name`, `Time`, `Profile`)을 포함합니다.
- `MeMessageModel`과 `YouMessageModel`은 각각 프로필 이미지를 설정하는 하위 클래스입니다.
- 모델 자체에는 별도의 비즈니스 로직이 포함되지 않으며, 데이터 구조만을 정의하는 역할을 합니다.

**2. ViewModel (뷰 모델)**
- Model과 View 사이의 중간 역할을 수행합니다.
- `MainWindowViewModel`에서는 `ObservableCollection<MessageModel>`을 사용하여 채팅 메시지를 관리합니다.
- 초기 샘플 데이터를 생성하여 UI에서 바로 사용할 수 있도록 설정합니다.
- 데이터 바인딩을 활용하여 View와 연결됩니다.

**3. Styles (스타일)**
- UI 요소의 일관성을 유지하기 위한 스타일 및 테마 정의를 포함합니다.
- 공통적인 디자인 요소를 관리하여 재사용성을 높입니다.

**4. View (뷰)**
- 사용자가 직접 상호작용하는 화면을 구성합니다.
- ViewModel에서 제공하는 데이터를 시각적으로 표현합니다.
- Avalonia XAML을 사용하여 UI를 구성합니다.


## 기타 참고 사항

- MVVM 패턴을 기반으로 설계되었으므로, 관심 분리를 유지하면서 개발을 진행할 수 있습니다.
- 스타일을 활용하여 UI 디자인을 일관되게 유지할 수 있습니다.

본 자료를 통해 프로젝트를 보다 쉽게 이해하시길 바랍니다!
