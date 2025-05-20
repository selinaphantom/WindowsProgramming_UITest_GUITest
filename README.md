MyDrawing 是一款使用 **C#** 開發，專門用於繪製流程圖的應用程式。本專案基於 **MVC 架構** 與 **物件導向設計（OOP）** 原則開發，並具備完善的 **UI 測試與 GUI 測試**。使用者可以透過圖形介面直覺式地建立與編輯流程圖節點與連線。

## 📌 專案特色

-  可視化建立流程圖：支援節點（Start、Process、Decision 等）與連線建立、拖曳、刪除、編輯。
-  採用 MVC 架構：將邏輯、畫面與控制流程清楚分離，方便維護與擴充。
-  使用物件導向設計：所有圖形皆以類別封裝，並透過介面與繼承達成擴充性。
-  包含 UI 測試與 GUI 測試，確保程式邏輯與使用者介面功能正確。
-  命令模式支援 Undo/Redo 功能。

##  架構說明

### MVC 架構模組

| 模組 | 內容 |
|------|------|
| **Model** | 管理所有流程圖圖形與資料邏輯（`Model.cs`） |
| **View** | 提供使用者操作介面，包含 `Form1.cs`、自訂面板與視覺元件 |
| **Controller** | 處理使用者輸入、繪圖狀態管理（如 DrawState、DrawLineState） |
| **Command** | 命令模式封裝所有操作行為，支援 Undo/Redo |
| **Factory** | 工廠模式建立流程圖圖形實體（Start、Process、Decision 等） |
| **Interface** | 各模組間使用之抽象介面（IShape、IGraphics、ICommand 等） |

##  專案結構
```
MyDrawing/
├── Homework Summary.doc
├── MyDrawing.sln
├── .vs/
│   ├── MyDrawing/
│   │   ├── CopilotIndices/
│   │   │   ├── 0.2.1653.9816/
│   │   │   │   ├── CodeChunks.db
│   │   │   │   ├── SemanticSymbols.db
│   │   │   │   ├── SemanticSymbols.db-shm
│   │   │   │   ├── SemanticSymbols.db-wal
│   │   ├── FileContentIndex/
│   │   │   ├── *.vsidx
│   │   ├── v15/, v17/
│   │   │   ├── .suo, layout.json, testlog, etc.
├── MyDrawing/
│   ├── App.config
│   ├── DoubleBufferedPanel.cs
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Form1.resx
│   ├── MyDrawing.csproj
│   ├── packages.config
│   ├── Program.cs
│   ├── .vs/
│   │   ├── MyDrawing.csproj.dtbcache.json
│   ├── Command/
│   │   ├── ADDCommand.cs
│   │   ├── CommandManager.cs
│   │   ├── DeleteCommand.cs
│   │   ├── DeleteLineCommand.cs
│   │   ├── DrawCommand.cs
│   │   ├── DrawLineCommand.cs
│   │   ├── MoveCommand.cs
│   │   ├── TextChangeCommand.cs
│   │   ├── TextMoveCommand.cs
│   ├── Factory/
│   │   ├── Factory.cs
│   ├── Icon/
│   ├── Interface/
│   │   ├── ICommand.cs
│   │   ├── IGraphics.cs
│   │   ├── IShape.cs
│   │   ├── IState.cs
│   ├── Model/
│   │   ├── Model.cs
│   ├── PresentationModel/
│   │   ├── PresentationStateModel.cs
│   ├── Shape/
│   │   ├── Decision.cs
│   │   ├── Line.cs
│   │   ├── Process.cs
│   │   ├── Shape.cs
│   │   ├── Start.cs
│   │   ├── Terminator.cs
│   ├── State/
│   │   ├── DrawLineState.cs
│   │   ├── DrawState.cs
│   │   ├── IState.cs
│   │   ├── PointState.cs
│   ├── ViewObject/
│   │   ├── EditForm.cs
│   │   ├── EditForm.Designer.cs
│   │   ├── EditForm.resx
│   │   ├── FormGraphicsAdaptor.cs
MyDrawingTests/
├── Command/
│   ├── ADDCommandTests.cs
│   ├── DeleteCommandTests.cs
│   ├── DeleteLineCommandTests.cs
│   ├── DrawCommandTests.cs
│   ├── DrawLineCommandTests.cs
│   ├── MoveCommandTests.cs
│   ├── TextChangeCommandTests.cs
│   ├── TextMoveCommandTests.cs
├── GUItest/
│   ├── MyDrawingGUITest.cs
│   ├── Robot.cs
├── Shape/
│   ├── DecisionTests.cs
│   ├── LineTests.cs
│   ├── ProcessTests.cs
│   ├── ShapeTests.cs
│   ├── StartTests.cs
│   ├── TerminatorTests.cs
├── Model/
│   ├── ModelTests.cs
```
## 測試資訊

本專案包含以下兩種測試：

- **UI 單元測試**（單元級邏輯驗證）
  - 位於 `MyDrawingTests/Command/`、`Shape/`、`Model/` 等目錄。
- **GUI 自動化測試**
  - 位於 `MyDrawingTests/GUItest/`，包含 `Robot.cs` 自動模擬滑鼠與鍵盤操作。
