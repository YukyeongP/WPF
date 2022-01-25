# WPF
1. 회원 가입을 위한 UI Prototype을 WPF로 구현

2. 사용자 컨트롤의 이벤트 연결 처리
  - 상하좌우, 윈도우 확대축소 이벤트 생성 

3. 신규 회원 추가, 선택 삭제, 회원 목록 표시
  - MVVM 패턴 연습
  
  ** ObservableCollection
  - 리스트 내용이 추가되거나 변경될 때 자동으로 바인딩작업해줌.
  - INotifyCollectionChanged를 기본으로 제공(동적 바인딩됨).
  - CollectionChanged 기본 컬렉션이 변경 될 때마다 발생해야하는 이벤트 노출.
  - 일반 List 컬렉션에 추가적으로 바인딩기능을 심어놓은 컬렉션.
  - 옵저버 패턴이 적용되어 바뀌면 알아서 UI에 반영(List<T>는 변경된 List의 내용을 UI에서 실시간으로 반영하지 않음.
  
  ** View는 ViewModel을 DataContext로만 알고, ViewModel은 View와 관련된 UI 객체를 전혀 모르도록 함.
