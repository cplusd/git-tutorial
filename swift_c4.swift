    //生物类
    class Living
    {
        func grow()
        {
        }
    }
    //动物类
    class Animal:Living
    {
        func move(){}
    }
    class Plant:Living
    {
        var leaves:Array<Leave>!   //叶子属性
        var position:Position!     //生长位置属性
        func photosynthesis(){}    //光合作用
    }
    
    //水果类
    class Fruit:Plant
    {
        func fruct(){} // 结果方法
    }
    //桃子类
    class Peach:Fruit
    {
        func graft(){}  //嫁接方法
        override init()
        {
            super.init()
            self.leaves=[Leave.init(color: "green")]
        }
        
        override func grow() {
            print("new grow of peach")
        }
        func grow(speed:Int) {
            print("增长速度")
        }
        
    }
    
    struct Position
    {
        var longitude:Double=0
        var latitude:Double=0
    }
    
    struct Leave
    {
        var color:String!
        init(color:String)
        {
            self.color=color
            print("\(color)叶子")
        }
        
    }
    
    
