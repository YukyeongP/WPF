# WPF
1. 회원 가입을 위한 UI Prototype을 WPF로 구현

2. 사용자 컨트롤의 이벤트 연결 처리
  - 상하좌우, 윈도우 확대축소 이벤트 생성 

3. 신규 회원 추가, 선택 삭제, 회원 목록 표시
  - MVVM 패턴 연습
  
  * ObservableCollection
    - 리스트 내용이 추가되거나 변경될 때 자동으로 바인딩작업해줌.
    - INotifyCollectionChanged를 기본으로 제공(동적 바인딩됨).
    - CollectionChanged 기본 컬렉션이 변경 될 때마다 발생해야하는 이벤트 노출.
    - 일반 List 컬렉션에 추가적으로 바인딩기능을 심어놓은 컬렉션.
    - 옵저버 패턴이 적용되어 바뀌면 알아서 UI에 반영(List<T>는 변경된 List의 내용을 UI에서 실시간으로 반영하지 않음.
  
  * View는 ViewModel을 DataContext로만 알고, ViewModel은 View와 관련된 UI 객체를 전혀 모르도록 함.
  
4.
  1) 회원 정보
 - 나이 값을 변경하면 회원 목록에 자동 반영 v 
: MemListUserControl.xaml 
1. IsLiveGroupingRequested="True"(https://docs.microsoft.com/ko-kr/dotnet/api/system.windows.data.collectionviewsource.islivegroupingrequested?view=netframework-4.7.2 
2. <TextBox ~ Text="{Binding SelectedUser.Age, UpdateSourceTrigger=LostFocus}" />)
:propertyChanged하면 텍스트가 바로 읽혀서 x 포커스잃었을 때 업데이트 되어야함
-> 없어도됨

 - 값 변경 시 신규 회원 목록과 같은 수준으로 유효 값 처리 v
 :UserInfo에서 처리

  2) 신규 회원 목록
 - 유효한 값 처리
  (1) 나이 v
  (2) 성별(여/남/모름) v
  (3) 생년월일 - 달력으로 v -> 받는 날짜 수정필요

 - 등록 / 취소 시 화면 전환(바인딩처리 안해도 무관) v 
: Messenger.Default.Send / Register 사용 V

+ 메인윈도우 화면전환 버튼 바인딩으로 변경 v (MainWindow.xaml, xaml.cs)
(참고사이트: https://afsdzvcx123.tistory.com/entry/C-WPF-WPF-Multiple-View-UserControl-%EC%9D%B4%EC%9A%A9-%EA%B5%AC%ED%98%84)
+ 잘못입력시 회원목록에 저장 안되도록 (UserDataSource.cs / 추후 조건 추가)  v
+ 버튼색 v
