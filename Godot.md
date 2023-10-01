# 介绍
## 简介

1. Godot 最初是由阿根廷游戏工作室内部开发的。它的开发始于 2001 年，自 2014 年开源发布以来，引擎经过了重写和巨大改进
2. 支持导入在 Blender 中设计的 3D 场景，并维护 VSCode 和 Emacs 中针对 GDScript 和 C# 的代码插件。还支持 Windows 上的 Visual Studio for C#
3. 编程语言支持（官方）
   1. GDScript（一种特定于 Godot 且具有轻量级语法的紧密集成语言）
   2. C#
4. 使用 GDExtension技术，还可以用C或C++编写**游戏玩法或高性能算法**，无需重新编译引擎。可以使用此技术在引擎中集成第三方库和其他软件开发工具包 (SDK)
## Godot 关键概念
四大概念：在 Godot 中，游戏是一棵**节点树（tree of nodes ）**，将这些节点组合在一起形成**场景（scenes）**。之后可以连接这些节点，以便它们可以使用**信号**进行通信**（signals）**
### Scenes

1.  在 Godot 中，可以**将游戏分解为可重复使用的场景**。场景可以是**角色**、**武器**、**用户界面中的菜单**、**单个房屋**、**整个关卡**或任何能想到的东西（类似其他游戏引擎中的预制件和场景）
2. 场景可以嵌套：例如，可以将角色放入关卡中，然后拖放场景作为其子级（预制件的父子关系）

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695445868677-e608fa6a-23c9-4345-ae13-a137f7d77f62.webp#averageHue=%23bbcebb&clientId=u96580abd-01c6-4&from=paste&id=u5d04386b&originHeight=363&originWidth=782&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uaa3449b9-2d5a-4f95-b9c7-f515635dd0b&title=)
### Nodes

1. 场景由一个或多个**节点**组成。节点是游戏中最小的构建块，可以将其排列成树
2. 角色节点的示例

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695446070080-8b84d0ec-438c-4c50-a107-1e9ddd5ea6d2.webp#averageHue=%2371cb68&clientId=u96580abd-01c6-4&from=paste&id=uf538988e&originHeight=295&originWidth=609&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u433a0df5-9302-49ca-8e5e-217801335b4&title=)
它由名为“Character”的 **CharacterBody2D** 节点、 **Sprite2D** 、 **Camera2D** 和 **CollisionShape2D** 组成
> 节点名称以“2D”结尾，因为这是一个 2D 场景。它们的 3D 对应项的名称以“3D”结尾。注意：从 Godot 4 开始，“空间”节点现在称为“Node3D”

3. 如何让**节点**和**场景**在编辑器中看起来一样：当**节点树**保存为**场景**时，它会**显示为单个节点**，其内部结构隐藏在编辑器中
4. Godot 提供了丰富的基本节点类型库，可以自由组合和扩展以构建更强大的节点类型。 主要有三类： **2D、3D 、用户界面**

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695446615813-4cf79068-ff89-4599-b729-9c440140fb39.png#averageHue=%232b313c&clientId=u96580abd-01c6-4&from=paste&height=539&id=u3c967a97&originHeight=674&originWidth=1179&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=84897&status=done&style=none&taskId=ubf4297e6-9f9f-411b-b917-914f727eba7&title=&width=943.2)
### The scene tree

1.  所有游戏场景都聚集在场景树中，实际上是一棵场景树。由于**场景是节点树**，场景树也是节点树。但从场景的角度来思考你的游戏会更容易，因为它们可以代表角色、武器、门或你的用户界面

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695446797268-3c2909bf-9ea9-4e1f-a764-d7abc60bef69.webp#averageHue=%232c323b&clientId=u96580abd-01c6-4&from=paste&id=u04d92c31&originHeight=342&originWidth=291&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uc004dd3e-2c5d-4131-aeb3-e64842289e1&title=)

2. 可以理解场景树是一个根节点？
### Signals

1.  当某些事件发生时，节点会发出信号。此功能允许您**使节点进行通信**，而无需在代码中对它们进行硬连接。为构建场景提供了很大的灵活性（下图在程序窗口右侧）

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695446886454-e761d86e-1eca-42d9-a7be-5ec8fccc97da.webp#averageHue=%232f353d&clientId=u96580abd-01c6-4&from=paste&id=ua9fde624&originHeight=369&originWidth=305&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uc1355a55-e61a-4cb0-b517-754c6aa3b83&title=)

2. 例如：按钮在按下时会发出信号。可以连接到此信号以运行代码来响应此事件，例如开始游戏或打开菜单（跟 GUI 的原理类似）
3. 内置信号：可以告诉您两个物体何时碰撞、角色或怪物何时进入给定区域等等。
也可以自定义信号
### **总结**
**节点**是游戏最小的构建块（基本单位）。可以将它们组合起来创建**场景**，将其组合并嵌套到**场景树**中。然后，可以使用**信号**使节点对其他节点或不同场景树分支中的事件做出反应
场景树套场景，场景套节点，节点通过信号通讯。（场景是不是也可以看作节点？）
## Godot的编辑器
### The Project Manager（开始界面）

1. 启动 Godot 时，看到的第一个窗口是项目管理器。在默认选项卡“本地项目”中，可以管理现有项目、导入或创建新项目等等

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695447501909-d7c2d75a-c5e6-41d2-ac03-01f91f6abe7e.png#averageHue=%23262c35&clientId=u96580abd-01c6-4&from=paste&height=556&id=FEig0&originHeight=695&originWidth=1170&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=111067&status=done&style=none&taskId=u2890f2b1-bde2-45aa-90cf-8af7fef63c9&title=&width=936)

2. 在窗口顶部，还有另一个名为“资产库项目”的选项卡。可以在**开源资源库**中搜索演示项目，其中包括许多社区开发的项目

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695447527226-3ab305e7-c00f-444f-9370-5489977f775d.png#averageHue=%23292f38&clientId=u96580abd-01c6-4&from=paste&height=556&id=u3ec958a8&originHeight=695&originWidth=1170&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=182723&status=done&style=none&taskId=u5d3eb26d-46fe-4146-ab7f-28a19342793&title=&width=936)
### 编辑器
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695449501919-6bf96db0-b5e1-49b3-8526-2281b5cf0012.webp#averageHue=%2348544c&clientId=u96580abd-01c6-4&from=paste&id=u26f41a0f&originHeight=737&originWidth=1301&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u5b6e976c-fb6f-493d-bf83-1fb5a6aee0a&title=)

1. 工具栏：根据上下文和所选节点而变化

2D 工具栏
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695449853777-1f69dff7-5b4a-432b-99eb-47cc16a750c6.webp#averageHue=%233d4452&clientId=u96580abd-01c6-4&from=paste&id=uf0dce09d&originHeight=36&originWidth=596&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u91873b8d-62c4-4daf-8fd0-e8a4e247ca3&title=)
3D
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695449860032-5df68a4b-8cfd-48a8-b1da-a5e63ad15f8e.webp#averageHue=%233d4452&clientId=u96580abd-01c6-4&from=paste&id=uacc08084&originHeight=36&originWidth=608&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u9361f0d2-cb3d-41d1-bd99-c1803dab65c&title=)

2. 左侧边栏
   1. 文件系统：列出了项目文件，包括脚本、图像、音频样本等（跟项目根目录结构一致）

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695449954570-a0988bbf-595d-45ff-88e0-52fbaeaba262.webp#averageHue=%2329303a&clientId=u96580abd-01c6-4&from=paste&height=340&id=u188a3266&originHeight=340&originWidth=184&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ua52ae0c6-5e62-4816-bec9-35103a1bada&title=&width=184)

   2.  场景停靠栏列出了活动场景的节点

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695450037141-abf6afec-e343-4686-97a9-dfd403b2202d.webp#averageHue=%23333945&clientId=u96580abd-01c6-4&from=paste&height=339&id=u06dadcf3&originHeight=339&originWidth=184&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u32b03813-1bdb-4516-bd81-b06702841b4&title=&width=184)

3. 检查器：允许编辑选定节点的属性

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695450117615-8762caaa-7a2c-49a0-9770-fc83230e40b6.webp#averageHue=%23353b44&clientId=u96580abd-01c6-4&from=paste&id=u61eddf2c&originHeight=285&originWidth=220&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uf846fea0-63c1-4a08-ba81-0c24ce1b3c6&title=)

4. 底部面板位于视口最下方，是调试控制台、动画编辑器、音频混合器等的主要区域。它们会占用宝贵的空间，默认折叠

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695450365970-ce33e268-222c-47e1-a356-8bc95f775636.png#averageHue=%23272c36&clientId=u96580abd-01c6-4&from=paste&height=231&id=u4ec4c073&originHeight=289&originWidth=1988&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=33846&status=done&style=none&taskId=u69e5e779-4591-4850-8769-538a6c5d778&title=&width=1590.4)

5. 四个主屏幕

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695450530982-40c45613-3836-4426-b3e8-a7108d926951.png#averageHue=%23252b33&clientId=u5c944e4a-01dd-4&from=paste&height=36&id=ud79c24e1&originHeight=45&originWidth=341&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=3674&status=done&style=none&taskId=ua4c8a7e2-fa58-49bc-99df-c020c30684d&title=&width=272.8)
主要说一下脚本屏幕：是一个完整的代码编辑器，带有调试器、丰富的自动完成功能和内置代码参考。右上角的搜索帮助能**看内置的类参考文档，有中文**
![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695450645679-82e09695-83de-4ce7-9e54-517dc462ea71.png#averageHue=%2321272e&clientId=u5c944e4a-01dd-4&from=paste&height=817&id=u6019d148&originHeight=1021&originWidth=1992&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=184431&status=done&style=none&taskId=u079b926f-ee06-457c-88bb-fab1dd40339&title=&width=1593.6)
AssetLib 中可以找到免费开源的组件、脚本和资源
# 基础操作
## 节点和场景
### 节点

1. 节点是游戏的基本构建块。它们就像食谱中的原料。有几十种，可以显示图像、播放声音、代表相机等等的类型
2. 所有节点都具有以下特征
   - A name：一个名字
   - Editable properties：可编辑的属性
   - They receive callbacks to update every frame：可以收到更新每一帧的回调
   - You can extend them with new properties and functions：可以使用新的属性和功能来扩展它们
   - You can add them to another node as a child：可以将它们作为子节点添加到另一个节点

最后一个特征很重要。节点一起形成一棵树，这是组织项目的强大功能。由于不同的节点具有不同的功能，将它们组合起来会产生更复杂的行为
### 场景

1. 当组织树中的节点时，就像我们的角色一样，我们将其称为构建场景。保存后，场景就像编辑器中的**新节点**类型一样工作，可以**将它们添加为现有节点的子节点，**在这种情况下，**场景的实例显示为单个节点**，其**内部结构被隐藏**
2. 场景可以根据需要构建游戏代码。可以**组合节点**来创建自定义和复杂的节点类型，例如可以奔跑和跳跃的游戏角色、生命条、可以与之交互的箱子等等
3. Godot 编辑器本质上是一个场景编辑器：它拥有大量用于编辑 2D 和 3D 场景以及用户界面的工具。 Godot 项目可以包含任意多个场景。该引擎只**需要一个作为应用程序的主场景**。这是运行游戏时 Godot 将首先加载的场景
4. 除了充当节点之外，场景还具有以下特征：
   1. They always have one root node, like the "Character" in our example.
它们总是有一个根节点
   2. You can save them to your local drive and load them later.
可以将它们保存到本地驱动器并稍后加载
   3. You can create as many instances of a scene as you'd like. You could have five or ten characters in your game, created from your Character scene.
可以根据需要创建任意数量的场景实例。您的游戏中可以有五个或十个角色，这些角色是根据角色场景创建的
5. 补充：场景可以理解为多个节点的集合，或者称其为预制件（Unity 中的概念），比如一个人物身体可以由胳膊腿脑袋等（节点）部分构成，组合好这些节点后这个人物就可以作为单独的组件使用，而这个组件又可以作为其他组件的组成部分
> 场景是按树结构组织的节点的集合，以单个节点作为根，可以将项目拆分为任意数量的场景。此功能可帮助您分解和组织游戏的不同组件

### 创建第一个场景

1. 创建一个新项目
2. 在空场景中，左侧的场景停靠栏显示多个用于快速添加根节点的选项。 “2D Scene”添加 Node2D 节点，“3D Scene”添加 Node3D 节点，“User Interface”添加 Control 节点。这些预设是为了方便起见；它们不是强制性的。 “其他节点”允许您选择任何节点作为根节点。
左边的加号可以添加一个新节点作为当前选中节点的子节点

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695452852033-172d377d-7395-41fa-a94a-1b49184d561e.png#averageHue=%232e353f&clientId=u5c944e4a-01dd-4&from=paste&height=180&id=cRdpy&originHeight=225&originWidth=283&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=12591&status=done&style=none&taskId=ufcf988f0-883b-4138-a670-7338c33e649&title=&width=226.4)![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695452978581-f87e63b6-190a-4502-91b5-5a77fc117539.webp#averageHue=%232e343e&clientId=u5c944e4a-01dd-4&from=paste&height=190&id=u293cd8f1&originHeight=253&originWidth=286&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ua020754b-ad2a-4875-8b93-f18698a1aae&title=&width=215)

3. 向场景添加一个标签节点。它的功能是在屏幕上绘制文本

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695453089451-7049839c-3849-4e93-a521-910fb2e0b8bf.png#averageHue=%23282e38&clientId=u5c944e4a-01dd-4&from=paste&height=598&id=uf477d491&originHeight=747&originWidth=918&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=51572&status=done&style=none&taskId=u44483e8e-4346-4a1f-a7ae-5c851becda3&title=&width=734.4)

4. 添加场景的第一个节点时会发生很多事情。场景更改为 2D 工作空间，因为 Label 是 2D 节点类型。选定的标签将出现在视口的左上角
该节点显示在左侧的“场景”面板中，节点的属性显示在右侧的“检查器”面板中

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695453153371-ea2693f2-7059-4cc6-875a-628027f7b201.webp#averageHue=%2379b67e&clientId=u5c944e4a-01dd-4&from=paste&id=u55d6f214&originHeight=648&originWidth=1152&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u9b15141c-a11b-48e6-b20f-f11daed849d&title=)
### 更改节点属性

1. 更改标签的“文本”属性。将其更改为“Hello World”
2. 视口右侧的检查器下方。单击 Text 属性下方的字段并输入“Hello World”

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695453437455-5e628aa8-5f63-466c-aa45-12fd171b3e45.png#averageHue=%2382ab86&clientId=u5c944e4a-01dd-4&from=paste&height=556&id=u51d533c3&originHeight=695&originWidth=1170&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=198221&status=done&style=none&taskId=ua9ca63d1-4ffd-4a76-8075-abcf4f67d5d&title=&width=936)

3. 上面的一排选项按钮可以辅助控制节点的位置等属性
### 运行场景

1. 按屏幕右上角的“播放场景”按钮

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695453668329-28e7cb39-dd8f-4819-a7dd-c64d0d86ae4c.webp#averageHue=%23232830&clientId=u5c944e4a-01dd-4&from=paste&id=u7c0fe03d&originHeight=45&originWidth=337&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u7b37a2d2-3fa9-4c0e-9d1d-2e0bfdd5f83&title=)

2. 弹出窗口会邀请您保存场景，这是运行场景所必需的。单击文件浏览器中的“保存”按钮将其另存为“label.tscn”

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695453701415-dbca1abc-3555-4fc7-97f5-326cf1857951.png#averageHue=%23282e38&clientId=u5c944e4a-01dd-4&from=paste&height=598&id=ub7c92181&originHeight=747&originWidth=1068&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=42684&status=done&style=none&taskId=u1720bc08-b753-4ee7-98e6-3142d0c1e72&title=&width=854.4)

3. 运行场景后在新窗口中打开并显示文本“Hello World”

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695453929563-332133d5-e111-4852-bedd-034c26131eb5.png#averageHue=%2390a397&clientId=u5c944e4a-01dd-4&from=paste&height=556&id=uabdd9004&originHeight=695&originWidth=1170&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=182023&status=done&style=none&taskId=u313f8ef6-38d6-4df1-8c52-2fbb6b4b161&title=&width=936)
### 设置主场景

1. 为了运行我们的测试场景，我们使用了“播放场景”按钮。它旁边的另一个按钮允许您设置和运行项目的主场景

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695454016726-ce83674a-9e61-4cb1-b571-8d9a5ec1c6f4.webp#averageHue=%23232830&clientId=u5c944e4a-01dd-4&from=paste&id=u0279cecc&originHeight=46&originWidth=339&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u3e6d3c22-030a-42bc-927d-d681caf6c5f&title=)

2. 将出现一个弹出窗口并邀请您选择主场景

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695454049376-b2c4c68b-344e-49e0-9dc9-61963f602e67.webp#averageHue=%233c424e&clientId=u5c944e4a-01dd-4&from=paste&id=ue7058e46&originHeight=124&originWidth=514&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u0720bab8-fecd-4520-85e2-fe54ab2c04c&title=)
![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695454077981-29fd6e82-1382-4167-b355-384924eac512.png#averageHue=%23292f3a&clientId=u5c944e4a-01dd-4&from=paste&height=598&id=u5389b0b1&originHeight=747&originWidth=1068&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=46111&status=done&style=none&taskId=u8694d40b-e65b-4175-8ce6-4c4da3a3078&title=&width=854.4)

3. 选择后演示会再次运行，以后每次运行该项目时，Godot 都会使用这个场景作为起点
## 创建实例

1. 前面提到可以根据需要创建任意数量的场景，并将它们保存为扩展名为 **.tscn** 的文件，该扩展名代表“文本场景”。**label.tscn** 文件就是一个示例。
我们将这些文件称为**“打包场景”**，因为它们打包了有关场景内容的信息
2. 例子：该场景由一个名为 Ball 的根节点（允许球下落并在墙壁上弹跳的 RigidBody2D 节点）、一个 Sprite2D 节点和一个 CollisionShape2D 组成

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695454664960-e1495174-6903-4026-9a0d-d1ca153d96c9.png#averageHue=%237fb16c&clientId=u5c944e4a-01dd-4&from=paste&id=u4ef482a7&originHeight=209&originWidth=514&originalType=url&ratio=1.25&rotation=0&showTitle=false&size=15857&status=done&style=none&taskId=ucdede854-5e2e-4c84-9bc8-6e92e99df6a&title=)
保存场景后，它就可以用作蓝图（模板）：可以根据需要多次在其他场景中重现它。像这样从模板复制对象称为实例化（**instancing**）
![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695454748490-18104281-f618-4ba2-baf4-e32db28c741d.png#averageHue=%23574952&clientId=u5c944e4a-01dd-4&from=paste&id=ua4a8bfd9&originHeight=394&originWidth=935&originalType=url&ratio=1.25&rotation=0&showTitle=false&size=73695&status=done&style=none&taskId=ub464186f-1f8c-4f91-bf53-57f19e9ad03&title=)

3. 实例场景的行为就像一个节点：编辑器默认隐藏其内容。当实例化 Ball 时，您只能看到 Ball 节点。请注意每个副本需要具有**唯一的名称**
4. Ball 场景的每个实例都以与 ball.tscn 相同的结构和属性开始。但是，可以单独修改每个属性，例如更改它们的弹跳方式、重量或源场景公开的任何属性
**（可以理解场景为类，每个实例是一个对象，类只控制对象初始的默认值）**
## 项目演示

1. 下载官方演示实例项目：[instancing_starter.zip](https://github.com/godotengine/godot-docs-project-starters/releases/download/latest-4.x/instancing_starter.zip)
2. 导入项目后看到项目的结构

该项目包含两个打包场景： **main.tscn** ，包含球碰撞的墙壁，以及 **ball.tscn** 。主场景应该会自动打开
![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695455954433-d0fec5a8-b6f3-4098-961e-a70abaa3da3b.png#averageHue=%23839b87&clientId=u5c944e4a-01dd-4&from=paste&height=556&id=u00513f6c&originHeight=695&originWidth=1170&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=222488&status=done&style=none&taskId=uda3bab6e-5cff-4587-9804-d40b31dea6f&title=&width=936)

3. 添加一个球作为主节点的子节点：在场景停靠栏中，选择主节点。然后，单击场景停靠栏顶部的链接图标。此按钮允许您添加场景实例作为当前选定节点的子节点

![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695456043726-d76d523f-5960-4f05-ae92-f473a654fb26.png#averageHue=%23333947&clientId=u5c944e4a-01dd-4&from=paste&id=udfaa0eec&originHeight=159&originWidth=263&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u67bd5534-7d83-4726-bea2-00415804512&title=)
双击球场景以实例化它
![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695456072119-f0be2d66-d28b-45f7-958e-9d798bcdae56.png#averageHue=%23303748&clientId=u5c944e4a-01dd-4&from=paste&id=u36757dcf&originHeight=377&originWidth=1151&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u3ec17583-6f6d-4e55-b447-072f7140640&title=)
球出现在视口的左上角
![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695456109341-6baeaa86-343a-46f7-bc50-ef7b23c5141c.png#averageHue=%2347704c&clientId=u5c944e4a-01dd-4&from=paste&id=ue46f54ca&originHeight=738&originWidth=1300&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u04f1a66a-8979-4ced-8f0f-bf5043f4924&title=)

4. 移动小球到合适的位置，按 F5 玩游戏（在 macOS 上按 Cmd + B ）。应该看到它掉下来

![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695456221152-562fdb3a-b519-4f06-9439-d26797113d06.png#averageHue=%2354565c&clientId=u5c944e4a-01dd-4&from=paste&id=u6f027ba4&originHeight=379&originWidth=646&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u76a8cb4b-0c7c-4f00-af6f-2c3ceab4e23&title=)

5. 想要创建 Ball 节点的更多实例。在球仍处于选中状态的情况下按 Ctrl-D （在 macOS 上为 Cmd-D ）来复制实例。单击并拖动将新球移动到不同位置

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695456371265-bbf3798e-07e2-4402-95c5-a67e4db6389d.png#averageHue=%235a9e98&clientId=u5c944e4a-01dd-4&from=paste&id=uc52ba2b4&originHeight=655&originWidth=1044&originalType=url&ratio=1.25&rotation=0&showTitle=false&size=118667&status=done&style=none&taskId=u3f61f0af-4e38-46ba-bb4d-e1c99e349e6&title=)

6. 再次玩游戏。现在应该看到每个球都独立下落。这就是实例所做的事情。每个都是模板场景的独立再现
7. 补充：该项目还给 main 场景写了一个脚本，游戏运行中每点击一次鼠标就会创建一个球

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695456597330-b7a96a1d-7013-4dda-9f24-1c01d883d415.png#averageHue=%23242a32&clientId=u5c944e4a-01dd-4&from=paste&height=401&id=u0eef0c61&originHeight=501&originWidth=1075&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=76849&status=done&style=none&taskId=u64861a60-f70f-41a9-b890-0e196433e4d&title=&width=860)
## 编辑场景和实例
### 编辑实例
在检查器更改一个球的属性而不影响其他球
单击视口上方的相应选项卡选择主场景
![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695457186721-ac83ff85-73b9-4011-ac68-5c5259028c3e.png#averageHue=%2378b444&clientId=u5c944e4a-01dd-4&from=paste&id=ue5ba344b&originHeight=236&originWidth=237&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uf7cc3d1d-2720-4301-b739-0ce4cda3a78&title=)
选择实例化的 Ball 节点之一，然后在检查器中将其 Gravity Scale 值（重力）设置为 **10**
调整后的属性旁边会出现一个灰色的“恢复”按钮
![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695457242192-6bac5a6a-afe9-4842-8709-cc68d6f8cf74.png#averageHue=%232a2f3c&clientId=u5c944e4a-01dd-4&from=paste&id=u8f97bd5c&originHeight=34&originWidth=345&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ucd196750-9177-4acb-aa13-4cf52576b35&title=)
重新运行游戏并注意这个球现在下落的速度比其他球快得多
### 编辑场景
通过打开 ball.tscn 场景并更改其中的 Ball 节点来更改每个 Ball 的默认属性。保存后，项目中球的所有实例都将看到其值更新
打开 **ball.tscn** 并选择 Ball 节点。在右侧的检查器中，单击“PhysicsMaterial”属性将其展开，通过单击数字字段、输入 **0.5** 并按 Enter 将其 Bounce 属性设置为 **0.5** 
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695456897840-b8615e64-4411-4f2f-b7a5-7d7f8d22218e.webp#averageHue=%23303843&clientId=u5c944e4a-01dd-4&from=paste&id=u31d64251&originHeight=516&originWidth=272&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u2058cd77-1767-4259-ba3d-23688436def&title=)
按 F5 玩游戏，注意所有球现在弹跳得更多。由于 Ball 场景是所有实例的模板，修改它并保存会导致所有实例相应更新
### 注意
如果更改一个实例的 PhysicsMaterial 上的值，它将影响所有其他实例。
这是因为 PhysicsMaterial 是一个**资源（Resources** **）**，并且**资源在实例之间共享**。
要使某个资源对于一个实例是唯一的，请在检查器中右键单击该资源，然后在上下文菜单中单击“设为唯一”
![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695457463627-a282eb2a-6ad7-4d59-a2e6-cbba51fb7245.png#averageHue=%23373e4a&clientId=u5c944e4a-01dd-4&from=paste&height=227&id=u1c114ae0&originHeight=284&originWidth=260&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=19602&status=done&style=none&taskId=u2e78e5a4-dbfd-404c-b3be-55b25450f35&title=&width=208)
资源是 Godot 游戏的另一个重要组成部分，后面讲
### 场景实例作为设计语言
> Scene instances as a design language

Godot 中的实例和场景提供了出色的设计语言，使该引擎与其他引擎区分开来。我们从头开始就围绕这个概念设计了 Godot
官方建议：在使用 Godot 制作游戏时**放弃架构代码模式**，例如模型-视图-控制器 (MVC) 或实体关系图。相反，您可以**首先想象玩家将在游戏中看到的元素**，并**围绕它们构建代码**
例如，可以像这样分解射击游戏：
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695457630743-d695a2a4-a7b4-43bd-9551-32ec78b50460.webp#averageHue=%23181b21&clientId=u5c944e4a-01dd-4&from=paste&id=u38b41543&originHeight=210&originWidth=600&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u2ac15840-7b60-4628-8156-ba8ec1a8130&title=)
几乎可以为任何类型的游戏绘制这样的图表。每个**矩形代表**一个从玩家角度在游戏中可见的**实体**。**箭头**告诉您**哪个场景拥有哪个场景**
建好图表后，为其中列出的每个元素创建一个场景来开发游戏。您将通过代码或直接在编辑器中使用实例来构建场景树
基于场景的设计使开发变得更快、更简单，让您可以专注于游戏逻辑本身。由于**大多数游戏组件直接映射到场景**，因此使用**基于场景实例化**的设计意味着您几乎不需要其他架构代码
包含大量资源和嵌套元素的开放世界游戏的场景图示例
![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695457810228-f2ec57a9-7e9b-4c75-8948-11d76db4194a.png#averageHue=%2316181e&clientId=u5c944e4a-01dd-4&from=paste&id=ubefe74e7&originHeight=210&originWidth=600&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ucc271c78-7ee7-4a3d-91ae-0eb10c3eaf9&title=)
**总结：使用 Godot，需要做的就是创建和实例化更多场景，无限套娃**
## 脚本语言

1. 可用的脚本语言
Godot 提供四种游戏编程语言：GDScript、C#，以及通过其 GDExtension 技术提供的 C 和 C++（不做了解）。还有更多社区支持的语言，但这些是官方语言
2. 可以在一个项目中使用多种语言
例如，在团队中，可以使用 **GDScript 编写游戏逻辑**，因为它编写速度很快。使用 **C# 或 C++ 来实现复杂的算法**并最大限度地提高其性能。或者您可以用 GDScript 或 C# 编写所有内容
3. 选择语言
   1. 初学者，建议从 GDScript 开始。官方专门为 Godot 和游戏开发者的需求制作了这种语言。它具有轻量级且简单的语法，并提供与 Godot 最紧密的集成，可以直接在 godot 编辑器中写
   2. C# 需要一个外部代码编辑器，例如 VSCode 或 Visual Studio。虽然 C# 支持现已成熟，但与 GDScript 相比，它的学习资源较少，适合已经有编程语言经验的人
### GDScript
GDScript 是一种为 Godot 构建的**面向对象**的**命令式**编程语言。它由游戏开发者制作，旨在节省您编写游戏的时间。特点包括

- A simple syntax that leads to short files.
简单的语法，生成的文件很小
- Blazing fast compilation and loading times.
编译和加载时间极快
- Tight editor integration, with code completion for nodes, signals, and more information from the scene it's attached to.
紧密的编辑器集成，具有节点、信号及其所附加场景的更多信息的代码完成功能
- Built-in vector and transform types, making it efficient for heavy use of linear algebra, a must for games.
内置**向量**和**变换**类型，使其能够高效地大量使用游戏必需的**线性代数**
- Supports multiple threads as efficiently as statically typed languages.
像静态类型语言一样高效地**支持多线程**
- No [garbage collection](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science)), as this feature eventually gets in the way when creating games. The engine counts references and manages the memory for you in most cases by default, but you can also control memory if you need to.
没有垃圾收集，因为此功能最终会妨碍创建游戏。默认情况下，引擎会计算引用数并为您管理内存，但如果需要，您也可以控制内存
- [Gradual typing](https://en.wikipedia.org/wiki/Gradual_typing). Variables have dynamic types by default, but you also can use type hints for strong type checks.
渐进类型：变量**默认是动态类型**，也可以使用类型提示进行强类型检查

使用**缩进**构建代码块时，GDScript 看起来像 Python，但在实践中它的工作方式并不相同。它的灵感来自多种语言，包括 Squirrel、Lua 和 Python
### C#

1. 注意：必须使用 Godot 编辑器的 .NET 版本来编写 C# 脚本，可以在可以在Godot网站的[下载页面](https://godotengine.org/download/)上下载它
2. 由于 Godot 使用 .NET 6，理论上，可以在 Godot 中使用任何第三方 .NET 库或框架，以及任何符合公共语言基础结构的编程语言
3. GDScript 代码本身的执行速度不如编译后的 C# 或 C++
然而，大多数脚本代码在引擎内部调用用 C++ 代码中的快速算法编写的函数。在许多情况下，使用 GDScript、C# 或 C++ **编写游戏逻辑**不会对性能产生重大影响
4. 使用 Godot 4.x 用 C# 编写的项目目前无法导出到 Android、iOS 和 Web 平台。要在这些平台上使用 C#，需改用 Godot 3
## 创建第一个脚本

1. GDScript 示例
```javascript
# Everything after "#" is a comment.
# A file is a class!

# (optional) icon to show in the editor dialogs:
@icon("res://path/to/optional/icon.svg")

# (optional) class definition:
class_name MyClass

# Inheritance:
extends BaseClass

# Member variables.
var a = 5
var s = "Hello"
var arr = [1, 2, 3]
var dict = {"key": "value", 2: 3}
var other_dict = {key = "value", other_key = 2}
var typed_var: int
var inferred_type := "String"

# Constants.
const ANSWER = 42
const THE_NAME = "Charly"

# Enums.
enum {UNIT_NEUTRAL, UNIT_ENEMY, UNIT_ALLY}
enum Named {THING_1, THING_2, ANOTHER_THING = -1}

# Built-in vector types.
var v2 = Vector2(1, 2)
var v3 = Vector3(1, 2, 3)

# Functions.
func some_function(param1, param2, param3):
    const local_const = 5

    if param1 < local_const:
        print(param1)
    elif param2 > 5:
        print(param2)
    else:
        print("Fail!")

    for i in range(20):
        print(i)

    while param2 != 0:
        param2 -= 1

    match param3:
        3:
            print("param3 is 3!")
        _:
            print("param3 is not 3!")

    var local_var = param1 + 3
      return local_var

# Functions override functions with the same name on the base/super class.
# If you still want to call them, use "super":
func something(p1, p2):
    super(p1, p2)

# It's also possible to call another function in the super class:
func other_something(p1, p2):
    super.something(p1, p2)

# Inner class
class Something:
    var a = 10

# Constructor
func _init():
    print("Constructed!")
    var lv = Something.new()
    print(lv.a)
```
有关脚本语法的内容后面介绍

2. 创建一个新项目，从头开始。项目应该包含一张图片：Godot 图标
3. 创建一个 Sprite2D 节点来在游戏中显示它

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695494683027-0bf95d2f-806d-4443-af04-5386819330fc.webp#averageHue=%232a303a&clientId=u2b500e42-3ce6-4&from=paste&id=u7962f0a3&originHeight=122&originWidth=278&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ubba4b269-ae94-4f3b-a5f2-dfec0968885&title=)

4. Sprite2D 节点需要纹理才能显示。在右侧的检查器中，您可以看到纹理属性显示“[空]”。要显示 Godot 图标，请单击文件 icon.svg 并将其从文件系统停靠栏拖动到纹理槽上
（把图片直接拖到窗口里会自动创建Sprite2D 节点）

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695494866394-ef033adc-353d-40de-b51c-199fa7913c03.webp#averageHue=%23353c48&clientId=u2b500e42-3ce6-4&from=paste&id=ube5e7b0e&originHeight=223&originWidth=254&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u49a49043-08e7-4ae2-b063-eda7ff5d7e1&title=)

5. 拖动视口中的图标，使其在游戏视图中居中
6. 右键场景栏中的的 Sprite2D 节点并选择“添加脚本”

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695495123584-e39cea47-09bc-41e9-beca-09e405224366.png#averageHue=%23343b46&clientId=u2b500e42-3ce6-4&from=paste&height=297&id=u6132ca66&originHeight=371&originWidth=383&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=27217&status=done&style=none&taskId=uf6c1dd4f-a131-4fe2-890c-add2a14c995&title=&width=306.4)

7. 选择脚本的语言和文件路径以及其他选项，将模板字段从“节点：默认”更改为“对象：空”以从干净的文件开始

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695495245824-5cadb2be-47a8-4c5f-bc61-7b2bd9dfb05b.png#averageHue=%232b323c&clientId=u2b500e42-3ce6-4&from=paste&height=456&id=ua7a260d7&originHeight=570&originWidth=458&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=37468&status=done&style=none&taskId=u26cb9710-0fbb-4a23-ad86-0135f40f670&title=&width=366.4)![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695495584711-3824b8ad-c10d-45a2-b927-7ab0a9039ae1.png#averageHue=%23262c35&clientId=u2b500e42-3ce6-4&from=paste&height=210&id=ua45e2172&originHeight=262&originWidth=480&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=17018&status=done&style=none&taskId=ub4a86b5b-62b1-4368-843a-b0d26a86e7b&title=&width=384)
每个 GDScript 文件都是隐式的一个类。 **extends** 关键字定义此脚本继承或扩展的类。在本例中，它是 **Sprite2D** ，这意味着我们的脚本将访问 Sprite2D 节点的所有属性和函数，包括它扩展的类，例如 **Node2D** 、 **CanvasItem** 和 **Node** 
> 在 GDScript 中，如果省略带有 extends 关键字的行，您的类将隐式扩展 RefCounted，Godot 使用它来管理应用程序的内存

8. 让节点移动和旋转（比较简单，就不一步一步写了）
```javascript
extends Sprite2D

var speed = 400
var angular_speed = PI

func _process(delta):
    rotation += angular_speed * delta
    var velocity = Vector2.UP.rotated(rotation) * speed
    position += velocity * delta
```
## 监听玩家输入
在 Godot 中，有两个主要工具来处理玩家的输入：

- 内置的输入回调：主要是 **_unhandled_input()** 。与 **_process()** 一样，它是一个内置虚拟函数，每次玩家按下按键时 Godot 都会调用它。您可以使用它来对并非每帧都发生的事件做出反应，例如按 Space 进行跳跃。要了解有关输入回调的更多信息，请参阅使用 [InputEvent](https://docs.godotengine.org/en/stable/tutorials/inputs/inputevent.html#doc-inputevent)
- **Input** 单例：单例是全局可访问的对象。 Godot 提供了对多个脚本的访问。它是检查每帧输入的正确工具

这里使用 **Input** 单例，因为我们需要知道玩家是否想要在每一帧转动或移动

1. 对于旋转，我们应该使用一个新变量： **direction** 。在我们的 **_process()** 函数中，将 **rotation += angular_speed * delta** 行替换为以下代码
```javascript
var direction = 0
if Input.is_action_pressed("ui_left"):
    direction = -1
if Input.is_action_pressed("ui_right"):
    direction = 1

rotation += angular_speed * direction * delta
```

   - **direction** 局部变量是一个乘数，表示玩家想要转向的方向。值为 **0** 表示玩家没有按下向左或向右箭头键。值 **1** 表示玩家想要右转， **-1** 表示玩家想要左转
   - 要检查此帧是否按下了某个键，我们调用 **Input.is_action_pressed()** 。该方法采用表示输入操作的文本字符串，如果按下操作则返回 **true** ，否则返回 **false**
   - 上面使用的两个操作“ui_left”和“ui_right”是在每个 Godot 项目中预定义的。当玩家按下键盘上的左箭头和右箭头或游戏手柄方向键上的左箭头和右箭头时，它们会分别触发
2. 按向上时移动：为了仅在按下键时移动，我们需要修改计算速度的代码。将以 **var velocity** 开头的行替换为以下代码
```javascript
var velocity = Vector2.ZERO
if Input.is_action_pressed("ui_up"):
    velocity = Vector2.UP.rotated(rotation) * speed
```

3. 总结
   1. Godot 中的每个脚本都代表一个类，并继承了引擎的某个内置类。由于类继承了属性，就可以访问诸如 **rotation** 和 **position** 等父类的属性（还有没多没用到的函数），通过一些逻辑改变这些属性，达到让节点动起来的效果
   2. Godot 提供了多个虚拟函数，可以定义它们来**将类与引擎连接起来**。其中包括 **_process()** ——可以理解为引擎每帧都会调用这个函数，这样就可以每帧都修改节点的属性。以及 **_unhandled_input()** ，用于接收输入事件
   3. **Input** 单例允许在代码中的任何位置对玩家的输入做出反应。特别是在 **_process()** 循环中使用
## 使用信号

1. 信号是节点在发生特定事件（例如按下按钮）时发出的消息。其他节点可以连接到该信号并在事件发生时调用函数
2. 信号是 Godot 中内置的一种委托机制，允许**一个游戏对象**对**另一个游戏对象**的更改**做出反应**，而无需它们相互引用。使用信号可以限制耦合并保持代码的灵活性
> 例如，屏幕上可能有一个代表玩家生命值的生命条。当玩家受到伤害或使用治疗药水时，您希望栏反映变化。为此，在 Godot 中，您需要使用信号

### 按钮

1. 创建一个新的主场景，其中包括一个按钮和我们在创建第一个脚本课程中创建的 **sprite_2d.tscn** 场景。通过菜单 Scene -> New Scene 创建一个新场景

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695498227203-90c39109-cf65-41e6-a0eb-b30001ceb8cd.png#averageHue=%233b424c&clientId=u2b500e42-3ce6-4&from=paste&height=106&id=ud7b7e6c2&originHeight=132&originWidth=331&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=14803&status=done&style=none&taskId=u59dd0985-add9-403e-b116-249012b7532&title=&width=264.8)

2. 在场景栏中，添加一个 Node2D 作为我们的根节点
3. 文件系统中，单击之前保存的 **sprite_2d.tscn** 文件并将其拖动到 Node2D 上以将其实例化
4. 添加另一个 Button 节点作为 Sprite2D 的同级节点（默认情况节点很小，可以手动拽大）

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695498345702-1eff9aca-51e3-4627-8fab-de1e4e8fe506.png#averageHue=%232a313b&clientId=u2b500e42-3ce6-4&from=paste&height=74&id=ua5bfad86&originHeight=93&originWidth=274&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=5451&status=done&style=none&taskId=uc5320730-1f29-4e91-80c3-5197d044d16&title=&width=219.2)![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695498389669-cb3f0fd5-4dc8-4ef7-a044-0d70701bee90.webp#averageHue=%23da9e4f&clientId=u2b500e42-3ce6-4&from=paste&id=u87adcb60&originHeight=157&originWidth=225&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uf8e88ec7-8bcd-47f9-97e0-9d170a79545&title=)

5. 可以通过在检查器中编辑按钮的 Text 属性来在按钮上写字
6. 将新创建的场景保存为 **node_2d.tscn **后运行场景，此时按下按钮没反应
7. 想将按钮的“按下”信号连接到 Sprite2D，并且想要调用一个新函数来打开和关闭其运动。我们需要将一个脚本附加到 Sprite2D 节点
8. 选择“按钮”节点，然后在编辑器右侧单击“检查器”旁边名为“节点”的选项卡，可以看到所选节点上可用信号的列表

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695498546519-f8a62ee0-a826-4042-81c7-27aad780330b.webp#averageHue=%232f353f&clientId=u2b500e42-3ce6-4&from=paste&id=uf13eb383&originHeight=134&originWidth=317&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uae6e93f3-598c-4d84-a36a-99062ab4991&title=)![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695498557889-60916bd0-3f84-43d9-99c5-4dd3b4b0bb3a.webp#averageHue=%232c323b&clientId=u2b500e42-3ce6-4&from=paste&id=u5d7a3c08&originHeight=238&originWidth=317&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u13db5cd7-738c-455b-b25c-795132cac0f&title=)

9. 双击“按下”信号，打开节点连接窗口

![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695498596734-017c14d1-c681-4c3b-864b-3921ac7bd1d8.png#averageHue=%232b323c&clientId=u2b500e42-3ce6-4&from=paste&id=ud1883876&originHeight=381&originWidth=451&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ue11fae10-4f5a-452d-9498-1c9d485cd49&title=)

10. 可以将信号连接到 Sprite2D 节点。该节点需要一个接收器方法，这是当 Button 发出信号时 Godot 将调用的函数。编辑器会为您生成一个。按照惯例，我们将这些回调方法命名为“_on_node_name_signal_name”，在这里，它将是“_on_button_pressed”
> 通过编辑器的 Node Dock 连接信号时，您可以使用两种模式。简单的方法只允许您连接到附加了脚本的节点，并在它们上创建一个新的回调函数。高级视图允许您连接到任何节点和任何内置函数、向回调添加参数以及设置选项。您可以通过单击窗口右下角的“高级”按钮来切换模式
> ![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695498732443-56b6f6da-c588-4f74-bb9e-8f894d924755.png#averageHue=%232c323d&clientId=u2b500e42-3ce6-4&from=paste&id=u17725ade&originHeight=378&originWidth=680&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u769f6beb-b228-4c6e-917a-6adb6df0f53&title=)

11. 点击Connect按钮完成信号连接并跳转到Script工作区。您应该会在左侧看到带有连接图标的新方法。如果单击该图标，则会弹出一个窗口并显示有关连接的信息。此功能仅在编辑器中连接节点时可用

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1695498756044-d31591e0-effb-4daa-94da-134cd4c09429.webp#averageHue=%23242b33&clientId=u2b500e42-3ce6-4&from=paste&id=ua6f0d038&originHeight=110&originWidth=655&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u03fc66f0-4f92-4d29-9869-f23a59806a6&title=)

12. 把方法内容改一下，写上当按钮按下我们想执行的逻辑
此功能将在按下按钮时切换处理，并依次打开和关闭图标的运动
```javascript
func _on_button_pressed():
    set_process(not is_processing())

# 完整测试代码
extends Sprite2D

var speed = 400
var angular_speed = PI

func _process(delta):
    rotation += angular_speed * delta
    var velocity = Vector2.UP.rotated(rotation) * speed
    position += velocity * delta

func _on_button_pressed():
    set_process(not is_processing())
```
### 通过代码连接信号
可以通过代码连接信号，而不是使用编辑器
Godot 有一个计时器节点，可用于实现技能冷却时间、武器重新加载等

1.  给 Sprite2D 节点添加一个Timer子节点

![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695498963673-b48e6d78-4de5-4e79-bd07-884b4abe91e2.png#averageHue=%232f3741&clientId=u2b500e42-3ce6-4&from=paste&id=u29432da7&originHeight=132&originWidth=184&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uc2d9f60f-9b9e-477e-8d21-d138bb1529f&title=)

2.  选择“计时器”节点后，转到“检查器”并启用“自动启动”属性

![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695499006034-43ff94c9-e51c-4505-a07e-753d0e623119.png#averageHue=%232f3544&clientId=u2b500e42-3ce6-4&from=paste&id=uee65a372&originHeight=287&originWidth=280&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uf60a492f-8a1b-40a9-838a-fa26d106e2a&title=)

3. 两个操作来通过代码连接节点：
   1. 从 Sprite2D 获取对 Timer 的引用：使用 Node._ready()，Node.get_node() 方法在场景实例化时获取到节点
   2. 对计时器的“超时”信号调用 **connect()** 方法
```javascript
func _ready():
    var timer = get_node("Timer")
    timer.timeout.connect(_on_timer_timeout)
```

4. 完整示例代码
现在运行场景，将看到图标以一秒的间隔闪烁
```javascript
extends Sprite2D

var speed = 400
var angular_speed = PI

func _ready():
    var timer = get_node("Timer")
    timer.timeout.connect(_on_timer_timeout)

func _process(delta):
    rotation += angular_speed * delta
    var velocity = Vector2.UP.rotated(rotation) * speed
    position += velocity * delta

func _on_button_pressed():
    set_process(not is_processing())

func _on_timer_timeout():
    visible = not visible
```
### 自定义信号
例如，假设您希望在玩家的生命值为零时显示游戏结束屏幕。为此，您可以在健康状况达到 0 时定义一个名为“died”或“health_depleted”的信号
```javascript
extends Node2D

signal health_depleted

var health = 10
```
自定义信号的工作方式与内置信号相同：它们显示在“节点”选项卡中，您可以像其他信号一样连接到它们
![](https://cdn.nlark.com/yuque/0/2023/png/32839039/1695499333932-3328de3f-2840-4688-b87d-e63e9c05b6f1.png#averageHue=%23303842&clientId=u2b500e42-3ce6-4&from=paste&id=u24d5a87e&originHeight=176&originWidth=287&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ud9a51071-67bb-4602-a4b9-8118dc2ddb3&title=)
要在脚本中发出信号，需对该信号调用 **emit()**
```javascript
func take_damage(amount):
    health -= amount
    if health <= 0:
        health_depleted.emit()
```
信号可以选择声明一个或多个参数。指定括号之间的参数名称
```javascript
extends Node

signal health_changed(old_value, new_value)

var health = 10
```
要随信号一起发出参数值，请将它们作为额外参数添加到 **emit()** 函数中
```javascript
func take_damage(amount):
    var old_health = health
    health -= amount
    health_changed.emit(old_health, health)
```
# 第一个 2D 游戏
![](https://cdn.nlark.com/yuque/0/2023/gif/32839039/1696079802710-45d83f41-03a3-421a-9675-a33114106ed6.gif#averageHue=%233b6e71&clientId=u59e76106-7f2d-4&from=paste&id=u40e983b8&originHeight=370&originWidth=240&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ufcc87c82-1ed3-459d-943b-6b5ffe93531&title=)
您将学会：

- 使用 Godot 编辑器创建完整的 2D 游戏
- 构建一个简单的游戏项目
- 移动玩家角色并改变其精灵（sprite）
- 产生随机敌人
- 算分
## 创建项目

1. 下载 [dodge_the_creeps_2d_assets.zip](https://github.com/godotengine/godot-docs-project-starters/releases/download/latest-4.x/dodge_the_creeps_2d_assets.zip)。该存档包含您将用于制作游戏的图像和声音。解压存档并将 art/ 和 fonts/ 目录移动到项目目录
2. 该游戏是为纵向模式设计的，因此我们需要调整游戏窗口的大小。单击“项目”->“项目设置”打开项目设置窗口，然后在左栏中打开“显示”->“窗口”选项卡。在那里，将“视口宽度”设置为 **480** ，将“视口高度”设置为 **720**
3. 另外，在“拉伸”选项下，将“模式”设置为 **canvas_items** ，将“宽高比”设置为 **keep** 。这确保了游戏**在不同尺寸的屏幕上一致地缩放**
## 组织项目
主要是对项目目录进行清晰的规划，让项目结构便于理解
在这个项目中，我们将制作 3 个独立的场景： **Player** 、 **Mob** 和 **HUD** ，我们将把它们组合到游戏的 **Main** 中场景
在较大的项目中，创建**文件夹**来保存各种场景及其脚本可能很有用，但对于这个相对较小的游戏，您可以将场景和脚本保存在项目的根文件夹中，由 **res://** 标识。您可以在左下角的文件系统停靠栏中看到您的项目文件夹：
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696080276278-d1c35f30-b838-43c0-a1f4-782e98e4fcf5.webp#averageHue=%23262c35&clientId=u59e76106-7f2d-4&from=paste&id=ubc0057ce&originHeight=309&originWidth=314&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u2c76ede6-cac3-4dd6-a6c0-bb0ae66b9b4&title=)
## 创建玩家场景（player scene）
第一个场景将定义 **Player** 对象。创建单独的玩家场景的好处之一是我们可以单独测试它，甚至在我们创建游戏的其他部分之前也是如此

1.  为玩家对象选择一个根节点。作为一般规则，场景的根节点应反映对象所需的功能 - 即这个对象是个什么东西。单击“其他节点”按钮并将一个 Area2D 节点添加到场景中（节点旁边会有个警告图标。现在可以忽略，之后处理）
> 使用 **Area2D** 可以检测重叠或撞到玩家的对象

2. 双击节点将其名称更改为 **Player** 。现在我们已经设置了场景的根节点，我们可以添加其他节点以赋予其更多功能
3. 在将任何子节点添加到 **Player** 节点之前，我们希望确保不会通过单击它们来意外移动它们或调整它们的大小。选择节点并单击锁右侧的图标。它的工具提示显示**“使选定节点的子节点不可选择”**

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696080755808-6aa52a29-4113-44b0-9adf-26f67dc41b1a.webp#averageHue=%23323945&clientId=u59e76106-7f2d-4&from=paste&id=u4d6bdf37&originHeight=79&originWidth=590&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u96dfe857-d6a8-4d6f-bd3d-89f19869c7c&title=)

4. 对于这个项目，我们将遵循 Godot 命名约定
   1. GDScript：类（节点）使用PascalCase，变量和函数使用snake_case，常量使用ALL_CAPS（请参阅[GDScript风格指南](https://docs.godotengine.org/en/stable/tutorials/scripting/gdscript/gdscript_styleguide.html#doc-gdscript-styleguide)）
   2. C#：类、导出变量和方法使用 PascalCase，私有字段使用 _camelCase，局部变量和参数使用 CamelCase（请参阅[ C# 风格指南](https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/c_sharp_style_guide.html#doc-c-sharp-styleguide)）。连接信号时请小心准确地键入方法名称
## 精灵动画（Sprite animation）

1.  单击 **Player** 节点并添加 ( Ctrl + A ) 子节点 AnimatedSprite2D。 **AnimatedSprite2D** 将处理播放器的外观和动画。
> 请注意，该节点旁边有一个警告符号。 **AnimatedSprite2D** 需要 SpriteFrames 资源，它是它可以显示的动画的列表

2.  要创建一个，请在检查器中的 **Animation** 选项卡下找到 **Sprite Frames** 属性，然后单击“[empty]”->“New SpriteFrames”。再次点击打开“SpriteFrames”面板：

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1696081317969-56754712-03ee-4edf-bf63-938994631189.png#averageHue=%23353c46&clientId=u59e76106-7f2d-4&from=paste&height=249&id=u198baafd&originHeight=311&originWidth=297&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=24672&status=done&style=none&taskId=ue54bc8c4-dee9-4f6f-9aea-435d77009a5&title=&width=237.6)
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696081107596-bccf9bde-575c-4f6f-9d69-6ce1c5791a34.webp#averageHue=%232b313c&clientId=u59e76106-7f2d-4&from=paste&id=hXK5k&originHeight=358&originWidth=1040&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ue8c9c41a-540c-495f-8719-a931cf4d77b&title=)
左侧是动画列表。单击“默认”并将其重命名为“walk”。

3.  单击左上角的“添加动画”按钮创建第二个名为“up”的动画。在“文件系统”选项卡中找到播放器图像 - 它们位于您之前解压缩的 **art** 文件夹中。将每个动画的两个图像（名为 **playerGrey_up[1/2]** 和 **playerGrey_walk[1/2]** ）拖动到相应动画面板的“动画帧”一侧

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1696081495482-6b3cdc14-e23b-4438-9c16-62075220a87f.png#averageHue=%232c343f&clientId=u59e76106-7f2d-4&from=paste&height=272&id=u769827e9&originHeight=340&originWidth=932&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=31932&status=done&style=none&taskId=u26d6a0a5-7a18-4b35-9fb8-b217a54352b&title=&width=745.6)

4. 玩家图像对于游戏窗口来说有点太大，因此我们需要将其缩小。单击 **AnimatedSprite2D** 节点并将 **Scale** 属性设置为 **(0.5, 0.5)** 。您可以在检查器中的 **Node2D** 标题下找到它

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696081554660-52470daf-d349-43ed-b496-742131702799.webp#averageHue=%23272c33&clientId=u59e76106-7f2d-4&from=paste&id=ud4b993b7&originHeight=230&originWidth=298&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u40476a20-0fd5-48df-afa6-036b2c6f7a8&title=)

5. 最后，添加 CollisionShape2D 作为 **Player** 的子级。这将确定玩家的“碰撞区”，或其碰撞区域的边界。对于此角色， **CapsuleShape2D** 节点提供最佳拟合，因此在检查器中的“Shape”旁边，单击“[empty]”->“New CapsuleShape2D”。使用两个尺寸手柄，调整形状大小以覆盖精灵

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1696081690609-01727843-d625-4319-b641-54e2e17f20f9.png#averageHue=%233d4551&clientId=u59e76106-7f2d-4&from=paste&height=282&id=u2679cd9d&originHeight=352&originWidth=284&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=27721&status=done&style=none&taskId=u8e6afdb8-2e5c-4fe4-9b8b-faedfa62ccd&title=&width=227.2)![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696081702002-0083a0aa-4810-40a6-a1a0-9ee33444d856.webp#averageHue=%237ab454&clientId=u59e76106-7f2d-4&from=paste&height=281&id=u6aa7f9d9&originHeight=403&originWidth=324&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u8efe80fc-fa3f-467b-9f3f-688d9811abe&title=&width=226)

6. 完成后，您的 **Player** 场景应如下所示

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696081801581-1ce31fdc-ab16-454b-ab7e-c43b253c8482.webp#averageHue=%23282e37&clientId=u59e76106-7f2d-4&from=paste&id=ufa8ba3d8&originHeight=222&originWidth=286&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uae01a81b-68ff-43c6-9259-ed1ce3550fb&title=)
## 开始写代码
本节开始添加玩家移动、动画，并将其设置为检测碰撞

1. 单击 **Player** 节点，然后单击“附加脚本”按钮（这里都以 C#为例了）

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696081932614-48553a89-9f88-43ea-9fac-c09cb8bfbfaa.webp#averageHue=%232a313a&clientId=u59e76106-7f2d-4&from=paste&id=ufc8c4ff7&originHeight=268&originWidth=250&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u5ab8e7af-a75d-482d-9d04-4fe0c2f522a&title=)![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1696082197547-dcddaed4-6cc7-4efa-977e-859f50c036ca.png#averageHue=%232a303a&clientId=u59e76106-7f2d-4&from=paste&height=270&id=ubaa72f4d&originHeight=518&originWidth=458&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=34724&status=done&style=none&taskId=u50066cbe-e6c1-4b58-aa83-c83dba87cc9&title=&width=238.40000915527344)

2. 声明该对象需要的成员变量
> 在第一个变量 **speed** 上使用 **export** 关键字允许我们在检查器中设置其值。这对于您希望能够像节点的内置属性一样进行调整的值来说非常方便。单击 **Player** 节点，您将看到该属性现在显示在检查器的“脚本变量”部分中。如果更改此处的值，它将覆盖脚本中写入的值

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1696082545457-42342ee0-9a21-4ea1-81e2-a6b4250e5a51.png#averageHue=%232d2c2c&clientId=u59e76106-7f2d-4&from=paste&height=646&id=nFz2n&originHeight=808&originWidth=1185&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=97831&status=done&style=none&taskId=u8d653c3e-8e7d-49e6-a3b0-61f9acf3097&title=&width=948)
点击右上角的 build 会构建 C#脚本，此时脚本中 Export 的属性会在检查器中看到并且修改
![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1696082643650-93d31f17-77bb-46b2-b018-15bc74b67f4c.png#averageHue=%232e343d&clientId=u59e76106-7f2d-4&from=paste&height=291&id=ZQdw0&originHeight=364&originWidth=303&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=25061&status=done&style=none&taskId=u7b0199fb-6827-4405-b528-bb4e471c02d&title=&width=242.4)

3. **_ready()** 函数在节点进入场景树时被调用，这是查找游戏窗口大小的好时机
```csharp
public override void _Ready()
{
    ScreenSize = GetViewportRect().Size;
}
```

4. 现在我们可以使用 **_process()** 函数来定义玩家将执行的操作。 **_process()** 每帧都会被调用，因此我们将使用它来更新游戏的元素，我们预计这些元素会经常更改。对于玩家来说，我们需要做以下事情
   - 检查输入：玩家是否按下了某个键？对于这个游戏，我们有 4 个方向输入需要检查。输入操作在“输入映射”下的项目设置中定义。在这里，您可以定义自定义事件并为其分配不同的按键、鼠标事件或其他输入。对于这个游戏，我们将箭头键映射到四个方向
   - 向指定方向移动
   - 播放适当的动画
5. 单击“项目”->“项目设置”打开项目设置窗口，然后单击顶部的“输入映射”选项卡。在顶部栏中输入“move_right”，然后单击“添加”按钮添加 **move_right** 操作，选择“确定”按钮。 “右”键现在与 **move_right** 操作关联

![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1696084149614-b9d706b6-dbfd-4c39-a83e-beaf5f20ff9a.png#averageHue=%23282f39&clientId=u59e76106-7f2d-4&from=paste&height=598&id=uf5b3762d&originHeight=747&originWidth=918&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=86629&status=done&style=none&taskId=ua9b92548-fcf3-48be-b367-91391efb396&title=&width=734.4)
重复这些步骤以添加另外三个映射
![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1696084242794-7d68c846-c79f-40fd-bce0-1831e04b717e.png#averageHue=%232a3038&clientId=u59e76106-7f2d-4&from=paste&height=194&id=u5a68c7d0&originHeight=243&originWidth=875&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=22719&status=done&style=none&taskId=ue9d5c843-e83c-4248-b8e8-2032874efa2&title=&width=700)

6. 可以使用 **Input.IsActionPressed("move_right")** 检测是否按下了某个键，如果按下则返回 **true** ，如果没有按下则返回 **false**
```csharp
public override void _Process(double delta)
{
    var velocity = Vector2.Zero; // The player's movement vector.

    if (Input.IsActionPressed("move_right"))
    {
        velocity.X += 1;
    }

    if (Input.IsActionPressed("move_left"))
    {
        velocity.X -= 1;
    }

    if (Input.IsActionPressed("move_down"))
    {
        velocity.Y += 1;
    }

    if (Input.IsActionPressed("move_up"))
    {
        velocity.Y -= 1;
    }

    var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

    if (velocity.Length() > 0)
    {
        velocity = velocity.Normalized() * Speed;
        animatedSprite2D.Play();
    }
    else
    {
        animatedSprite2D.Stop();
    }
}
```
首先将 **velocity** 设置为 **(0, 0)** - 默认情况下，玩家不应移动。然后我们检查每个输入并从 **velocity** 中添加/减去以获得总方向。例如，如果您同时按住 **right** 和 **down** ，则生成的 **velocity** 向量将为 **(1, 1)** 。在本例中，由于我们添加了水平和垂直移动，因此玩家的对角移动速度会比仅水平移动更快
如果我们标准化速度，这意味着我们将其长度设置为 **1** ，然后乘以所需的速度，我们可以防止这种情况发生。这意味着不再需要快速的对角线移动**（学一下向量数学）**

7. 检查玩家是否在移动，以便我们可以在 AnimatedSprite2D 上调用 **play()** 或 **stop()**
```csharp
//GetNode是Node类的方法，也是继承过来的，用于获取当前节点相对路径处的子节点
var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

if (velocity.Length() > 0)
{
    velocity = velocity.Normalized() * Speed;
    //控制动画是否播放
    animatedSprite2D.Play();
}
else
{
    animatedSprite2D.Stop();
}
```

8. 使用 **clamp()** 来阻止它离开屏幕。限制一个值意味着将其限制在给定的范围内。将以下内容添加到 **_process** 函数的底部（确保它没有在 else 下缩进）
```csharp
Position += velocity * (float)delta;
Position = new Vector2(
    x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
    y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
);
```
delta 参数指的是帧长度 - 前一帧完成所需的时间量。使用此值可确保即使帧速率发生变化，您的运动也将保持一致
此时运行场景，小人可以动了，并且上下左右动时播放动画，但只播放 up 的动画
## 选择动画
在玩家可以移动，我们需要根据 AnimatedSprite2D 的方向更改正在播放的动画。我们有“行走”动画，显示玩家向右行走。该动画应使用 **flip_h** 属性水平翻转以进行左移动。我们还有“向上”动画，应该使用 **flip_v** 垂直翻转以向下移动。让我们将此代码放在 **_process()** 函数的末尾
```csharp
if (velocity.X != 0)
{
    animatedSprite2D.Animation = "walk";
    animatedSprite2D.FlipV = false;
    // See the note below about boolean assignment.
    animatedSprite2D.FlipH = velocity.X < 0;
}
else if (velocity.Y != 0)
{
    animatedSprite2D.Animation = "up";
    animatedSprite2D.FlipV = velocity.Y > 0;
}
```
再次播放场景检查每个方向的动画是否正确
确定动作正常工作后，将`Hide();`添加到 **_ready()** ，以便游戏开始时玩家将被隐藏
## 为碰撞做准备
我们希望 **Player** 能够检测到它何时被敌人击中，但我们还没有制造任何敌人！没关系，因为我们将使用 Godot 的信号功能来使其工作
在脚本顶部添加以下内容。如果您使用 GDScript，请将其添加到 **extends Area2D** 之后。如果您使用的是 C#，请将其添加到 **public partial class Player : Area2D** 之后
```csharp
// Don't forget to rebuild the project so the editor knows about the new signal.

[Signal]
public delegate void HitEventHandler();
```
这定义了一个名为“hit”的自定义信号，当玩家与敌人碰撞时，我们将发出（发出）该信号。我们将使用 **Area2D** 来检测碰撞。选择 **Player** 节点并单击“检查器”选项卡旁边的“节点”选项卡以查看播放器可以发出的信号列表
![image.png](https://cdn.nlark.com/yuque/0/2023/png/32839039/1696086893131-2cef9d4e-c5ba-4f24-b624-a18b209b9f29.png#averageHue=%232f363f&clientId=u59e76106-7f2d-4&from=paste&height=406&id=u38ec3017&originHeight=508&originWidth=363&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=43946&status=done&style=none&taskId=u8a8bfc18-0188-473f-a0c7-05e233be444&title=&width=290.4)
请注意，我们的自定义“点击”信号也在那里！由于我们的敌人将是 **RigidBody2D** 节点，因此我们需要 **body_entered(body: Node2D)** 信号。当身体接触玩家时会发出此信号。单击“连接..”，将出现“连接信号”窗口。我们不需要更改任何这些设置，因此再次单击“连接”。 Godot 会自动在你的玩家脚本中创建一个函数（仅限于 GDScript，C#指挥跳到指定的类，需要手动添加方法）
```csharp
private void OnBodyEntered(PhysicsBody2D body)
{
    Hide(); // Player disappears after being hit.
    EmitSignal(SignalName.Hit);
    // Must be deferred as we can't change physics properties on a physics callback.
    GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
}
```
每次敌人击中玩家时，都会发出信号。我们需要禁用玩家的碰撞，这样我们就不会多次触发 **hit** 信号
如果禁用该区域的碰撞形状发生在引擎碰撞处理过程中，可能会导致错误。使用 **set_deferred() **告诉 Godot **禁用该形状**，直到安全为止
最后一部分是添加一个函数，我们可以在开始新游戏时调用该函数来重置玩家
```csharp
public void Start(Vector2 position)
{
    Position = position;
    Show();
    GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
}
```
## 创建敌人
现在是时候让我们的玩家必须躲避敌人了。他们的行为不会很复杂：小怪会在屏幕边缘随机生成，选择随机方向，并沿直线移动
我们将创建一个 **Mob** 场景，然后我们可以实例化该场景以在游戏中创建任意数量的独立生物

1. 从顶部菜单中单击“场景”->“新建场景”并添加以下节点，将子项设置为无法选择它们，就像在 Player 场景中所做的那样
   - RigidBody2D（名为 **Mob** ）
      - [AnimatedSprite2D](https://docs.godotengine.org/en/stable/classes/class_animatedsprite2d.html#class-animatedsprite2d)
      - [CollisionShape2D](https://docs.godotengine.org/en/stable/classes/class_collisionshape2d.html#class-collisionshape2d)
      - [VisibleOnScreenNotifier2D](https://docs.godotengine.org/en/stable/classes/class_visibleonscreennotifier2d.html#class-visibleonscreennotifier2d)
2. 在 RigidBody2D 属性中，将 **Gravity Scale**（几倍重力）设置为 **0** ，这样生物就不会向下掉落。此外，在 CollisionObject2D 部分下，取消选中 **Mask** 属性内的 **1** 。这将确保生物不会相互碰撞。

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696088531238-30859807-594f-43a2-92d9-dc2a3cba7b75.webp#averageHue=%232b323b&clientId=u59e76106-7f2d-4&from=paste&id=ud978a118&originHeight=294&originWidth=298&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u0a556735-0017-47fe-ae82-c53d8d7909d&title=)

3. 像为 **Player**  所做的那样设置 AnimatedSprite2D。这次，我们有 3 个动画： **fly** 、 **swim** 和 **walk** 。 art 文件夹中每个动画都有两张图像
必须为每个单独的动画设置 **Animation Speed** 属性。对于所有 3 个动画，将其调整为 **3**

![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696088629481-93907c46-0bac-4b4c-ae37-46c5c439ba74.webp#averageHue=%232b333e&clientId=u59e76106-7f2d-4&from=paste&id=uda57f84a&originHeight=358&originWidth=1040&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u47660886-81bb-4766-ad99-18caad838fd&title=)
可以使用 **Animation Speed** 输入字段右侧的“播放动画”按钮来预览动画
我们将随机选择这些动画之一，以便生物具有一定的多样性

4. 与玩家图像一样，这些生物图像也需要按比例缩小。将 **AnimatedSprite2D** 的 **Scale** 属性设置为 **(0.75, 0.75)**
5. 与 Player 场景一样，为碰撞添加 CapsuleShape2D 。要将形状与图像对齐，您需要将 Rotation Degrees 属性设置为 90 （在检查器中的“变换”下）
这是设置谁的角度？？？
6. 创建脚本

在 **_ready()** 中，我们播放动画并随机选择三种动画类型之一

   - 首先，我们从 AnimatedSprite2D 的 **frames** 属性中获取动画名称列表。这将返回一个包含所有三个动画名称的数组： **["walk", "swim", "fly"]** 
   - 然后，我们需要在 **0** 和 **2** 之间选择一个随机数，以从列表中选择这些名称之一（数组索引从 **0** 开始）。 **randi() % n** 选择 **0** 和 **n-1** 之间的随机整数
```csharp
public override void _Ready()
{
    var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    string[] mobTypes = animatedSprite2D.SpriteFrames.GetAnimationNames();
    animatedSprite2D.Play(mobTypes[GD.Randi() % mobTypes.Length]);
}
```
最后一步是让小怪在离开屏幕时删除自己。将 **VisibleOnScreenNotifier2D** 节点的 **screen_exited()** 信号连接到 **Mob** 并添加以下代码
```csharp
private void OnVisibleOnScreenNotifier2DScreenExited()
{
    QueueFree();
}
```
玩家和敌人准备就绪后，在下一部分中，我们会将他们聚集在一个新场景中。我们将使敌人在游戏板周围随机生成并向前移动，将我们的项目变成一个可玩的游戏
## 游戏主场景
创建一个新场景并添加一个名为 **Main** 的节点（我直接命名为 Game 了）。 （我们使用 Node 而不是 Node2D 的原因是因为该节点将成为处理游戏逻辑的容器。它本身不需要 2D 功能。）
单击“实例”按钮（由链链接图标表示）并选择您保存的 **player.tscn** 
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696089873963-4fddd275-92df-4444-aaa3-564d5d162fd2.webp#averageHue=%23272e38&clientId=u59e76106-7f2d-4&from=paste&id=u395ff9f1&originHeight=268&originWidth=250&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u3660ba44-c6f3-41e5-b3c5-a093bfd47ae&title=)
添加以下节点作为 **Main** 的子节点，并按所示命名它们（值以秒为单位）：

- [Timer](https://docs.godotengine.org/en/stable/classes/class_timer.html#class-timer) (named **MobTimer**) - to control how often mobs spawn
计时器（名为 **MobTimer** ）- 控制小怪生成的频率
- [Timer](https://docs.godotengine.org/en/stable/classes/class_timer.html#class-timer) (named **ScoreTimer**) - to increment the score every second
计时器（名为 **ScoreTimer** ） - 每秒增加分数
- [Timer](https://docs.godotengine.org/en/stable/classes/class_timer.html#class-timer) (named **StartTimer**) - to give a delay before starting
计时器（名为 **StartTimer** ）- 在开始之前给出延迟
- [Marker2D](https://docs.godotengine.org/en/stable/classes/class_marker2d.html#class-marker2d) (named **StartPosition**) - to indicate the player's start position
Marker2D（名为 **StartPosition** ） - 指示玩家的开始位置

设置每个 **Timer** 节点的 **Wait Time** 属性，如下所示：

- **MobTimer**: **0.5**
- **ScoreTimer**: **1**
- **StartTimer**: **2**

另外，将 **StartTimer** 的 **One Shot** 属性设置为“On”，并将 **StartPosition** 节点的 **Position** 设置为 **(240, 450)**
## 生成小怪
主节点将产生新的生物，我们希望它们出现在屏幕边缘的随机位置。添加名为 **MobPath** 的 Path2D 节点作为 **Main** 的子节点。当您选择 **Path2D** 时，您将在编辑器顶部看到一些新按钮
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696090219234-310d5785-a0b0-4644-bae4-99e01afc5a9b.webp#averageHue=%23333c48&clientId=u59e76106-7f2d-4&from=paste&id=u223a7f39&originHeight=66&originWidth=838&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ue2c8ee01-3ac3-4c5e-901c-d13e797f8f9&title=)
选择中间的一个（“添加点”），然后通过单击在所示角处添加点来绘制路径。要使点捕捉到网格，请确保同时选择“使用网格捕捉”和“使用智能捕捉”
这些选项位于“锁定”按钮的左侧，分别在一些点和相交线旁边显示为磁铁
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696090273496-7abb4989-fb22-4064-9ce0-c11430deec49.webp#averageHue=%23343d4a&clientId=u59e76106-7f2d-4&from=paste&id=u0038e113&originHeight=66&originWidth=838&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=udf98aba6-a27a-49ca-9e1b-7bca1f18e7e&title=)注意：按顺时针顺序绘制路径，否则小怪将生成指向外侧而不是内侧！
在图像中放置点 **4** 后，单击“关闭曲线”按钮，您的曲线将完成
![](https://cdn.nlark.com/yuque/0/2023/gif/32839039/1696090287410-86cd901f-6c1f-4de9-ac4e-81dcf2090d5f.gif#averageHue=%23494949&clientId=u59e76106-7f2d-4&from=paste&id=ua49f0620&originHeight=630&originWidth=406&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u29e9bbf3-1e4a-4bfa-b7ab-fc5a10f4e6e&title=)
现在已经定义了路径，添加一个 PathFollow2D 节点作为 **MobPath** 的子节点并将其命名为 **MobSpawnLocation** 。该节点在移动时会自动旋转并跟随路径移动，因此我们可以使用它来沿着路径选择随机位置和方向
你的场景应该是这样的
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696090518370-3934e156-7482-4230-a4c5-ba53068377f7.webp#averageHue=%23292e37&clientId=u59e76106-7f2d-4&from=paste&id=u93ebf8e7&originHeight=322&originWidth=250&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u5f6b904b-9c5f-4541-8959-02ba157ba41&title=)
## 主脚本
注意：下划线的变量命名方式是在 GDScript 中使用的，如果是私有方法会以下划线开头。在 C#中方法是大驼峰命名法（首字母大写），因为连接信号不会自动在 C#中创建方法，所以要自己把对应的方法添加到类中，方法名一定要和信号中定义的方法名一样
另外，信号在 C# 中的定义命名和 Timer 在项目中的命名都是有固定约定格式的

1.  将脚本添加到 **Main** 。在脚本的顶部，我们使用 **@export var mob_scene: PackedScene** 来选择我们想要实例化的 Mob 场景
```csharp
using Godot;

public partial class Main : Node
{
    // Don't forget to rebuild the project so the editor knows about the new export variable.

    [Export]
    public PackedScene MobScene { get; set; }

    private int _score;
}
```

2.  单击 **Main** 节点，您将在检查器中的“脚本变量”下看到 **Mob Scene** 属性，可以通过两种方式分配该属性的值：
   - 将 **mob.tscn** 从“文件系统”停靠栏拖放到 Mob 场景属性中。
   - 单击“[空]”旁边的向下箭头并选择“加载”。选择 **mob.tscn** 。
3.  接下来，在场景停靠栏中选择 **Main** 节点下的 **Player** 场景实例，然后访问侧边栏上的节点栏。确保在节点栏中选择了“信号”选项卡。
您应该会看到 **Player** 节点的信号列表。在列表中找到并双击 **hit** 信号（或右键单击它并选择“连接...”）。这将打开信号连接对话框。我们想要创建一个名为 **game_over** 的新函数，它将处理游戏结束时需要发生的事情。在信号连接对话框底部的“接收器方法”框中输入“game_over”，然后单击“连接”。您的目标是从 **Player** 发出 **hit** 信号并在 **Main** 脚本中进行处理。将以下代码添加到新函数以及 **new_game** 函数中，该函数将为新游戏设置所有内容
```csharp
public void GameOver()
{
    GetNode<Timer>("MobTimer").Stop();
    GetNode<Timer>("ScoreTimer").Stop();
}

public void NewGame()
{
    _score = 0;

    var player = GetNode<Player>("Player");
    var startPosition = GetNode<Marker2D>("StartPosition");
    player.Start(startPosition.Position);

    GetNode<Timer>("StartTimer").Start();
}
```

4.  现在将每个 Timer 节点（ **StartTimer** 、 **ScoreTimer** 和 **MobTimer** ）的 **timeout()** 信号连接到主脚本。 **StartTimer** 将启动另外两个计时器。 **ScoreTimer** 会将分数加 1
```csharp
private void OnScoreTimerTimeout()
{
    _score++;
}

private void OnStartTimerTimeout()
{
    GetNode<Timer>("MobTimer").Start();
    GetNode<Timer>("ScoreTimer").Start();
}
```

5.  在 **_on_mob_timer_timeout()** 中，我们将创建一个生物实例，沿 **Path2D** 随机选择一个起始位置，然后让生物开始运动。 **PathFollow2D** 节点会在沿着路径时自动旋转，因此我们将使用它来选择生物的方向及其位置。当我们生成一个生物时，我们将在 **150.0** 和 **250.0** 之间选择一个随机值来表示每个生物的移动速度（如果它们都以相同的速度移动，那就太无聊了） ）

请注意，必须使用 **add_child()** 将新实例添加到场景中
```csharp
private void OnMobTimerTimeout()
{
    // Note: Normally it is best to use explicit types rather than the `var`
    // keyword. However, var is acceptable to use here because the types are
    // obviously Mob and PathFollow2D, since they appear later on the line.

    // Create a new instance of the Mob scene.
    Mob mob = MobScene.Instantiate<Mob>();

    // Choose a random location on Path2D.
    var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
    mobSpawnLocation.ProgressRatio = GD.Randf();

    // Set the mob's direction perpendicular to the path direction.
    float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;

    // Set the mob's position to a random location.
    mob.Position = mobSpawnLocation.Position;

    // Add some randomness to the direction.
    direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
    mob.Rotation = direction;

    // Choose the velocity.
    var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
    mob.LinearVelocity = velocity.Rotated(direction);

    // Spawn the mob by adding it to the Main scene.
    AddChild(mob);
}
```
为什么使用 **PI** ？在需要角度的函数中，Godot 使用弧度，而不是度数。 Pi 代表半圈弧度，约为 **3.1415** （还有 **TAU** 等于 **2 * PI** ）。如果您更喜欢使用度数，则需要使用 **deg_to_rad()** 和 **rad_to_deg()** 函数在两者之间进行转换

6. 测试场景
```csharp
public override void _Ready()
{
    NewGame();
}
```
将 **Main** 指定为“主场景”——游戏启动时自动运行的场景。按“播放”按钮并在出现提示时选择 **main.tscn**
应该能够移动玩家，看到小怪生成，并看到玩家在被小怪击中时消失
场景一定要及时保存！！！要不然可能加载错误，血泪教训！！！
## 界面 UI（Heads up display）
游戏需要的最后一个部分是用户界面 (UI)，用于显示得分、“游戏结束”消息和重新启动按钮等内容

1. 创建一个新场景，并添加一个名为 **HUD** 的 CanvasLayer 节点。 “HUD”代表“平视显示器”，是一种信息显示，显示为游戏视图顶部的覆盖层
CanvasLayer 节点允许我们在游戏其余部分之上的层上**绘制 UI 元素**，它显示的信息**不会被任何游戏元素（例如玩家或生物）覆盖**

HUD需要显示以下信息：

   - 分数，由 **ScoreTimer** 更改。
   - 消息，例如“游戏结束”或“准备好！”
   - 一个“开始”按钮来开始游戏。

UI 元素的基本节点是 [Control](https://docs.godotengine.org/en/stable/classes/class_control.html#class-control)。为了创建 UI，我们将使用两种类型的控制节点：[标签](https://docs.godotengine.org/en/stable/classes/class_label.html#class-label)和[按钮](https://docs.godotengine.org/en/stable/classes/class_button.html#class-button)

2.  创建以下内容作为 **HUD** 节点的子节点：
   - [Label](https://docs.godotengine.org/en/stable/classes/class_label.html#class-label)：名为 **ScoreLabel** 的标签。
   - [Label](https://docs.godotengine.org/en/stable/classes/class_label.html#class-label)：名为 **Message** 的标签。
   - [Button](https://docs.godotengine.org/en/stable/classes/class_button.html#class-button)：名为 **StartButton** 的按钮。
   - [Timer](https://docs.godotengine.org/en/stable/classes/class_timer.html#class-timer)：名为 **MessageTimer** 的计时器。
3. 单击 **ScoreLabel** 并在检查器的 **Text** 字段中输入数字。 **Control** 节点的默认字体很小并且不能很好地缩放。游戏资源中包含一个名为“Xolium-Regular.ttf”的字体文件。要使用此字体，请执行以下操作：
在“主题覆盖 > 字体”下，选择“加载”并选择“Xolium-Regular.ttf”文件
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696140496795-8db7edcc-7d65-4ad0-a96c-3c0867bb054a.webp#averageHue=%23333942&clientId=u20e18d2f-3e09-4&from=paste&id=udc995d27&originHeight=466&originWidth=298&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u75074f06-1243-499e-8881-0956cc7c05a&title=)

字体大小仍然太小，请在“主题覆盖 > 字体大小”下将其增大到 **64** 。对 **ScoreLabel** 完成此操作后，请对 **Message** 和 **StartButton** 节点重复更改
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696140526226-e2346714-3aca-4c25-a9d3-5a7f40ea043d.webp#averageHue=%232b3139&clientId=u20e18d2f-3e09-4&from=paste&id=uee4ff0ea&originHeight=176&originWidth=298&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u34159ba1-1b4c-4abd-b107-9c2d3b08569&title=)

4. 如下所示排列节点。您可以拖动节点来手动放置它们，或者为了更精确的放置，请使用“锚点预设”
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696140622018-b213bbc4-01c0-41f0-82c4-86bb4c935e52.webp#averageHue=%23515151&clientId=u20e18d2f-3e09-4&from=paste&id=u75cbdfa6&originHeight=790&originWidth=513&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=u891e37d3-93cc-432c-971e-80445f05eda&title=)

ScoreLabel 分数标签

   1. 添加文本 **0** 
   2. 将“水平对齐方式”和“垂直对齐方式”设置为 **Center** 
   3. 选择“锚点预设” **Center Top** 

Message

   4. 添加文本 **Dodge the creeps!** 
   5. 将“水平对齐方式”和“垂直对齐方式”设置为 **Center** 
   6. 将“自动换行模式”设置为 **Word** ，否则标签将保留在一行上
   7. 在“Control - Layout/Transform”下，将“尺寸 X”设置为 **480** 以使用屏幕的整个宽度
   8. 选择“锚点预设” **Center** 

StartButton

   1. 添加文本 **Start** 
   2. 在“Control - Layout/Transform”下，将“X 大小”设置为 **200** ，将“Y 大小”设置为 **100** ，以在边框和文本之间添加更多的填充
   3. 选择 "Anchor Preset" **Center Bottom** 
   4. 在“Control - Layout/Transform”下，将“位置 Y”设置为 **580**

在 **MessageTimer** 上，将 **Wait Time** 设置为 **2** 并将 **One Shot** 属性设置为“On”

5. 添加脚本到 HUD
```csharp
using Godot;

public partial class HUD : CanvasLayer
{
    // Don't forget to rebuild the project so the editor knows about the new signal.

    [Signal]
    public delegate void StartGameEventHandler();
}
```
我们现在想要暂时显示一条消息，例如“准备好”，所以我们添加以下代码
```csharp
public void ShowMessage(string text)
{
    var message = GetNode<Label>("Message");
    message.Text = text;
    message.Show();

    GetNode<Timer>("MessageTimer").Start();
}
```
还需要处理玩家失败时会发生什么。下面的代码将显示“游戏结束”2 秒，然后返回到标题屏幕，并在短暂暂停后显示“开始”按钮
```csharp
async public void ShowGameOver()
{
    ShowMessage("Game Over");

    var messageTimer = GetNode<Timer>("MessageTimer");
    await ToSignal(messageTimer, Timer.SignalName.Timeout);

    var message = GetNode<Label>("Message");
    message.Text = "Dodge the\nCreeps!";
    message.Show();

    await ToSignal(GetTree().CreateTimer(1.0), SceneTreeTimer.SignalName.Timeout);
    GetNode<Button>("StartButton").Show();
}
```
当玩家失败时调用此函数。它将显示“游戏结束”2 秒，然后返回到标题屏幕，并在短暂暂停后显示“开始”按钮
> 当需要短暂暂停时，使用 Timer 节点的替代方法是使用 SceneTree 的 create_timer() 函数。这对于添加延迟非常有用，例如在上面的代码中，我们希望在显示“开始”按钮之前等待一段时间

将以下代码添加到 **HUD** 以更新分数
```csharp
public void UpdateScore(int score)
{
    GetNode<Label>("ScoreLabel").Text = score.ToString();
}
```
连接 **MessageTimer** 的 **timeout()** 信号和 **StartButton** 的 **pressed()** 信号（到 UHD 节点），并将以下代码添加到新函数中
```csharp
private void OnStartButtonPressed()
{
    GetNode<Button>("StartButton").Hide();
    EmitSignal(SignalName.StartGame);
}

private void OnMessageTimerTimeout()
{
    GetNode<Label>("Message").Hide();
}
```
## 将 HUD 连接到主屏幕
现在我们已经完成了 **HUD** 场景的创建，返回到 **Main** 。在 **Main** 中实例化 **HUD** 场景，就像您对 **Player** 场景进行实例化一样。场景树应该如下所示，因此请确保您没有错过任何内容
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696142073678-06ec273a-a6f4-4716-bbe1-1970a861ea74.webp#averageHue=%23292f37&clientId=u20e18d2f-3e09-4&from=paste&id=ub0a7e4ec&originHeight=340&originWidth=250&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ub7533b82-3e64-40ea-af98-ec41cbd2fc5&title=)

1. 将 **HUD** 功能连接到我们的 **Main** 脚本。这需要在 **Main** 场景中添加一些内容

把 HUD 的 **start_game** 信号连到 Main 场景的 **new_game()** 方法（请记住从 **_ready()** 中删除对 **new_game()** 的调用）

2. 在 **new_game()** 中，更新分数显示并显示“准备就绪”消息
```csharp
var hud = GetNode<HUD>("HUD");
hud.UpdateScore(_score);
hud.ShowMessage("Get Ready!");
```

3. 在 **game_over()** 中我们需要调用相应的 **HUD** 函数
```csharp
GetNode<HUD>("HUD").ShowGameOver();
```

4. 最后，将其添加到 **_on_score_timer_timeout()** 以使显示与变化的分数保持同步
```csharp
GetNode<HUD>("HUD").UpdateScore(_score);
```
此时可以开始游戏测试一下
## 移除旧的 Creep
如果您玩到“游戏结束”，然后立即开始新游戏，则上一游戏中的小兵可能仍会出现在屏幕上。如果他们在新游戏开始时全部消失，那就更好了。我们只需要一种方法来告诉所有怪物自行撤离。我们可以通过“组”功能来做到这一点
在 **Mob** 场景中，选择根节点并单击检查器旁边的“节点”选项卡（您可以在其中找到节点信号的同一位置）。在“信号”旁边，单击“组”，您可以输入新组名称，然后单击“添加”
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696143258918-14f5d2aa-349c-49e2-8c11-91911d6e8d2c.webp#averageHue=%232b323c&clientId=u20e18d2f-3e09-4&from=paste&id=u986ea4cf&originHeight=174&originWidth=298&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=uf8ad1bc2-257d-496f-a239-d10b02e15c9&title=)
现在所有的小怪都会在“mobs”组中。然后我们可以将以下行添加到 **Main** 中的 **new_game()** 函数中：
```csharp
// Note that for calling Godot-provided methods with strings,
// we have to use the original Godot snake_case name.
GetTree().CallGroup("mobs", Node.MethodName.QueueFree);
```
**call_group()** 函数调用组中每个节点上的命名函数 - 在这种情况下，我们告诉每个生物删除自己
游戏到这里就基本完成了。在下一部分也是最后一部分中，我们将通过添加背景、循环音乐和一些键盘快捷键来对其进行一些完善
## Finishing up 整理起来
现在已经完成了游戏的所有功能。以下是添加更多“果汁”以改善游戏体验的一些剩余步骤，可以随意用自己的想法扩展游戏玩法

1. 默认的灰色背景不太吸引人，所以让我们改变它的颜色。实现此目的的一种方法是使用 ColorRect 节点。使其成为 **Main** 下的第一个节点，以便将其绘制在其他节点后面。 **ColorRect** 只有一个属性： **Color** 。选择您喜欢的颜色，然后在视口顶部的工具栏中或检查器中选择“布局”->“锚点预设”->“全矩形”，使其覆盖屏幕
还可以使用 **TextureRect** 节点来添加背景图像（如果有）
2. 声音特效

声音和音乐是增加游戏体验吸引力的最有效方式。在游戏资产文件夹中，有两个声音文件：“House In a Forest Loop.ogg”用于背景音乐，“gameover.wav”用于玩家失败时的声音
添加两个 AudioStreamPlayer 节点作为 Main 的子节点。将其中一个命名为 Music ，将另一个命名为 DeathSound 。在每个文件上，单击 Stream 属性，选择“加载”，然后选择相应的音频文件
所有音频都会在禁用 Loop 设置的情况下自动导入。如果您希望音乐无缝循环，请单击流文件箭头，选择 Make Unique（唯一化，否则改不了属性） ，然后单击流文件并选中 Loop 框
要播放音乐，请在 new_game() 函数中添加` GetNode<AudioStreamPlayer2D>("Music").Play(); `，在 game_over() 函数中添加 `GetNode<AudioStreamPlayer2D>("Music").Stop();`
最后，在 game_over() 函数中添加 `GetNode<AudioStreamPlayer2D>("DeathSound").Play();`

3. 键盘快捷键

由于游戏是通过键盘控制的，如果我们也可以通过按键盘上的按键来启动游戏，那会很方便。我们可以使用 **Button** 节点的“Shortcut”属性来完成此操作
之前我们创建了四个输入动作来移动角色。现在我们将创建一个类似的输入操作来映射到开始按钮
选择“项目”->“项目设置”，然后单击“Input Map”选项卡。创建一个名为 **start_game** 的新输入操作，并为 Enter 键添加键映射
> 如果您有可用的控制器支持，现在是添加控制器支持的好时机。连接或配对您的控制器，然后在您想要添加控制器支持的每个输入操作下，单击“+”按钮，然后按您想要映射到相应输入操作的相应按钮、方向键或摇杆方向

在 **HUD** 场景中，选择 **StartButton** 并在检查器中找到其 Shortcut 属性。通过在框中单击来创建新的快捷方式资源，打开事件数组并通过单击数组 [InputEvent]（大小 0）向其中添加新的数组元素
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696145175227-ba0cd7e5-049b-4e23-ab51-1db93e8e0ce1.webp#averageHue=%232e3946&clientId=u20e18d2f-3e09-4&from=paste&id=u2aae97b3&originHeight=190&originWidth=334&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ucd890cf6-70db-4322-a77b-dc866db20e8&title=)
创建一个新的 InputEventAction 并将其命名为 **start_game**
![](https://cdn.nlark.com/yuque/0/2023/webp/32839039/1696145247031-d3fbcd84-b3af-430e-8a97-38041b3e645e.webp#averageHue=%232e3745&clientId=u20e18d2f-3e09-4&from=paste&id=uf75d4e98&originHeight=371&originWidth=334&originalType=url&ratio=1.25&rotation=0&showTitle=false&status=done&style=none&taskId=ufbaff250-443f-4271-9d6a-2bf54fe45b4&title=)
现在，当开始按钮出现时，您可以单击它或按 Enter 开始游戏
**Godot 中的第一个 2D 游戏完成！**
