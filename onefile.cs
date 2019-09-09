绑定语法：

1、

MyType 与 ObjC 的类型对应， TypeBase 与 ObjC 的基类对应， Protocol1 、 Prodocol2 与 ObjC 类型实现的协议对应。

[BaseType(typeof(TypeBase))]
interface MyType [: Prodocol1, Protocol2] {
      IntPtr Constructor(string foo);
}

2、interface
ObjC 的 interface 定义如下：

@interface KKGridView : UIScrollView
@end
对应的绑定语法如下：

[BaseType(typeof(UIScrollView))]
interface KKGridView {
}

3、protocol

ObjC 的 protocol 定义语法如下：

@protocol KKGridViewDataSource <NSObject>
@end

或者

@protocol KKGridViewDelegate <NSObject , UIScrollViewDelegate>
@end
ObjC 的 protocol 与 C# 的 interface 有些类似， 但是 protocol 中定义的方法有两种， optional 和 required ， 又有点儿像抽象类， MonoTouch 将其绑定为类， 并添加 ModelAttribute 标记， 对应的绑定语法分别为：

[Model, BaseType(typeof(NSObject))]
interface KKGridViewDataSource {
}
 
[Model, BaseType(typeof(UIScrollViewDelegate))]
interface KKGridViewDelegate {
}

4、instance method

实例方法绑定为对应的 C# 实例方法：
oc
- (NSString *)gridView:(KKGridView *)gridView titleForHeaderInSection:(NSUInteger)section;

c#
[Export("gridView:titleForHeaderInSection:")]
string GridViewTitleFoHeaderInSection(KKGridView gridView, uint section);

如果是 protocol 的 required 方法， 则在对应的 C# 方法上添加 Abstract 标记， 例如：
oc
- (NSUInteger)gridView:(KKGridView *)gridView numberOfItemsInSection:(NSUInteger)section;

c#
[Abstract, Export("gridView:numberOfItemsInSection:")]
uint GridViewNumberOfItemsInSection(KKGridView gridView, uint section);

5、class method

ObjC 中的 class method 与 C# 中的静态方法概念一致， 因此绑定为 C# 的静态方法， 例如：
oc
+ (id)cellForGridView:(KKGridView *)gridView;

c#
[Static, Export("cellForGridView:")]
KKGridViewCell CellFroGridView(KKGridView gridView);


6、property

ObjC 的属性通常由 setPropertyName 、 propertyName 两个方法组成， 绑定为 C# 的属性：
oc
@property (nonatomic) BOOL allowsMultipleSelection;

c#
[Export("allowsMultipleSelection")]
bool AllowsMultipleSelection { get; set; }
如果不是由默认的两个方法组成， 例如：
oc
@property (nonatomic, getter = isSelected) BOOL selected;

对应的绑定为：

c#
[Export("selected")]
bool Selected { [Bind("isSelected")]get; set; }

7、enum
枚举的绑定是最容易的， 不过要放在 enums.cs 文件中， 例如：
typedef enum {
   KKGridViewAnimationFade,
   KKGridViewAnimationResize,
   KKGridViewAnimationSlideLeft,
   KKGridViewAnimationSlideTop,
   KKGridViewAnimationSlideRight,
   KKGridViewAnimationSlideBottom,
   KKGridViewAnimationExplode,
   KKGridViewAnimationImplode,
   KKGridViewAnimationNone
} KKGridViewAnimation;


public enum KKGridViewAnimation {
   Fade,
   Resize,
   SlideLeft,
   SlideTop,
   SlideRight,
   SlideBottom,
   Explode,
   Implode,
   None
}


others
https://developer.xamarin.com/guides/cross-platform/macios/binding/objective-c-libraries/

a、绑定参数可已是null的方法
[Export ("setText:")]
string SetText ([NullAllowed] string text);


b、绑定静态属性

[Export ("currentRunLoop")][Static][IsThreadStatic]
NSRunLoop Current { get; }

c、可已null的属性

[Export ("text"), NullAllowed]
string Text { get; set; }

[Export ("text")]
string Text { get; [NullAllowed] set; }


D、Binding Constructors

（a）、 must return an IntPtr value 
（b）、 name of the method should be Constructor

[Export ("initWithFrame:")]
IntPtr Constructor (CGRect frame);

E、Binding Class Extensions

[Category, BaseType (typeof (NSString))]
interface NSStringDrawingExtensions {
        [Export ("drawAtPoint:withFont:")]
        CGSize DrawString (CGPoint point, UIFont font);
}

F、Binding Objective-C Argument Lists

G、Binding Fields

H、Binding Notifications
Binding Categories
Binding Blocks
Asynchronous Methods


、、、、、、、、、、、
Linking 

-gcc_flags "-L${ProjectDir} -lMylibrary -force_load -lSystemLibrary -framework CFNetwork -ObjC"

The above example will link libMyLibrary.a, libSystemLibrary.dylib and the CFNetwork framework library into your final executable.



==================================sharpie
sharpie bind --output=InfColorPicker --namespace=InfColorPicker --sdk=iphoneos11.4 [full-path-to-project]/InfColorPicker/InfColorPicker/*.h

转framework的方法
sharpie bind -framework xxx.framework -sdk iphoneos10.3

 
 --output=ConverterOfRadio --namespace=RadioConverter --sdk=iphoneos11.4 /Users/danny.qi/Library/Developer/Xcode/DerivedData/NTYAmrConverter-fbxanczbxhuaxigxhwjzlpgjdxpi/Build/Products/Debug-iphoneos/NTYAmrConverter.framework/Headers/NTYAmrConverter.h 

sharpie xcode -sdks
sdk: iphoneos12.2 

sharpie bind -framework /Users/tpc/Desktop/lib/Macaw.framework -sdk iphoneos12.4     sharpie bind -framework /Users/tpc/Desktop/lib/StitchCameraSDK.framework -sdk iphoneos12.4   sharpie bind -framework /Users/tpc/Desktop/lib/SWXMLHash.framework -sdk iphoneos12.4   

=======================
sharpie bind --output=InfColorPicker --namespace=InfColorPicker --sdk=[iphone-os] [full-path-to-project]/InfColorPicker/InfColorPicker/*.h


iphoneos10.1

sharpie bind \
    -sdk iphoneos8.1 \
    -output ZendeskSDK \
    -unified \
    ZendeskSDK.framework/Headers/ZendeskSDK.h \
    -c -F. -arch arm64 -v






