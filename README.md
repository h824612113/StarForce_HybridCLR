## 简介

使用 HybridCLR 对 StarForce 实现热更新。将 StarForce 的游戏逻辑剔除，可以得到一个接入了 HybridCLR 的 GameFramework。可 fork 此仓库使用 👉  [UnityGameFramework](https://github.com/GREAT1217/UnityGameFramework) 

### 更新日志
>在大佬的基础上进行后续修改[StarForce_HybridCLR](https://github.com/GREAT1217/StarForce_HybridCLR)

>更新最新的HyBridClr插件,2.1.0版本

>增加分包更新逻辑

> 增加删除分包更新逻辑


### 适用于 GameFramework 的工具

HybridCLR 官方的的工具流已经完善，在接入 GameFramework 时唯一需要扩展的就是：将热更新的 dll 文件，拷贝至 Assets 目录下，用于 Resource 模块资源编辑与打包。已在此工具的 Build 模块实现。

![编辑器工具](https://gitee.com/great1217/cdn/raw/master/images/HybridCLR_Builder.png)

### GameFramework 热更新流程图

![游戏流程图](https://gitee.com/great1217/cdn/raw/master/images/StarForce_Procedure.png)

## 鸣谢
**GameFramework** - [https://gameframework.cn/](https://gameframework.cn/)

**HybridCLR** - [https://focus-creative-games.github.io/hybridclr/](https://focus-creative-games.github.io/hybridclr/)