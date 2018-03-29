# WIN10-UI桌面图标分组支持插件
### 版本 v1.1
### 引入shortcut-drawer.min.css和shortcut-drawer.min.js就可使用
### DEMO（和其他图标html同级）:
~~~
            <div class="shortcut win10-drawer">
                <i class="icon fa fa-fw fa-star red"></i>
                <div class="title">二级菜单</div>
                <div class="win10-drawer-box">
                    <div class="shortcut-drawer win10-drawer">
                        <i class="icon fa fa-fw fa-star red"></i>
                        <div class="title">三级菜单</div>
                        <div class="win10-drawer-box">
                            <div class="shortcut-drawer win10-open-window" data-url="www.baidu.com">
                                <i class="icon fa fa-fw fa-th-list orange"></i>
                                <div class="title">子项1</div>
                            </div>
                            <div class="shortcut-drawer">
                                <i class="icon fa fa-fw fa-th-list orange"></i>
                                <div class="title">子项2</div>
                            </div>
                        </div>
                    </div>
                    <div class="shortcut-drawer win10-open-window" data-url="www.baidu.com">
                        <i class="icon fa fa-fw fa-th-list orange"></i>
                        <div class="title">子项1</div>
                    </div>
                    <div class="shortcut-drawer">
                        <i class="icon fa fa-fw fa-th-list orange"></i>
                        <div class="title">子项2</div>
                    </div>
                    <div class="shortcut-drawer">
                        <i class="icon fa fa-fw fa-th-list orange"></i>
                        <div class="title">子项2</div>
                    </div>
                    <div class="shortcut-drawer">
                        <i class="icon fa fa-fw fa-th-list orange"></i>
                        <div class="title">子项2</div>
                    </div>
                    <div class="shortcut-drawer">
                        <i class="icon fa fa-fw fa-th-list orange"></i>
                        <div class="title">子项2</div>
                    </div>
                    <div class="shortcut-drawer">
                        <i class="icon fa fa-fw fa-th-list orange"></i>
                        <div class="title">子项2</div>
                    </div>
                    <div class="shortcut-drawer">
                        <i class="icon fa fa-fw fa-th-list orange"></i>
                        <div class="title">子项2</div>
                    </div>
                    <div class="shortcut-drawer">
                        <i class="icon fa fa-fw fa-th-list orange"></i>
                        <div class="title">子项2</div>
                    </div>
                </div>
            </div>

~~~

> 作者：Yuri2

> 特别感谢：迷糊(541980655)，发掘了多级菜单的隐藏属性