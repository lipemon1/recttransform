# Rect Transform Extension
## _Lets gain some frames, or try at least_

We are trying here to gain processimg time by moving RectTransforms out of screen
Instead of enable and disable their game objects

## Installation
- If you want to download the raw script. Here it is
<a id="https://github.com/lipemon1/recttransform/blob/main/Assets/Scripts/CustomRectTransform.cs" href="https://raw.githubusercontent.com/lipemon1/recttransform/master/Assets/Scripts/CustomRectTransform.cs">CustomRectTransform.cs</a>

## What is does?
- It will change the position of a RectTransform out of screen. (You can set this value)
- If your object is disabled it will enable it for the first time. All objects will be enabled.
- It uses a Dictionary to prevent a RectTransform from moving more than one time, so, you can call a lot of toggle false/true in sequence. But, why would you do this bro?

## Benchmark
To test the performance of this little guy, I run some test using Unity Profiler here are the results.

But, before showing the results, the test was:

### Test method used

Run those two operations:
1. gameObject.SetActive **false** on a RectTransform.gameObject
2. gameObject.SetActive **true** on a RectTransform.gameObject

Run those two operations for a list of RectTransforms with size of 1, 10, 100 and 1000

After that we run other two commands:
1. rectTransform.ToggleUIObject **false** on a RectTransform
2. rectTransform.ToggleUIObject **true** on a RectTransform

Run those two operations for a list of RectTransforms with size of 1, 10, 100 and 1000

The object used on those two operations was the same:

![image](https://raw.githubusercontent.com/lipemon1/recttransform/main/img/prefab.PNG)

and the hierarchy was this:

![image](https://raw.githubusercontent.com/lipemon1/recttransform/main/img/hierarchy.PNG)

Now, the results:
### Results

| Type | Amount | Processing Time (ms) | GC Alloc (Kb) |
| ------ | ------ | ------ | ------ |
| GameObject.SetActive | 1 | 2,45 | 5,1 |
| New Extension Method | 1 | 0,52 | 0,6 |
|  |  |
| GameObject.SetActive | 10 | 3,32 | 43,7 |
| New Extension Method | 10 | 0,76 | 1,3 |
|  |  |
| GameObject.SetActive | 100 | 36,75 | 434,6 |
| New Extension Method | 100 | 0,51 | 12,4 |
|  |  |
| GameObject.SetActive | 1000 | 556,14 | 4200 |
| New Extension Method | 1000 | 5,18 | 121,4 |

Well, pretty much we seems to reduce the processing and memory allocation o/

To visually compare the processing time here is the graph:

![image](https://raw.githubusercontent.com/lipemon1/recttransform/main/img/processing.PNG)

To visually compare the memory allocation here is the graph:

![image](https://raw.githubusercontent.com/lipemon1/recttransform/main/img/gcalloc.PNG)

## Is this a Silver Bullet for Unity UI RectTransform?
Not at all, I mean, **NOT AT ALL**
It's just a alternative to SetActive on UI GameObjects, so don't use like a solution for everything but I hope that can help you to gain some frame processing time.

## Better than use, improve it
Help me make this little guy better for us. If you find any issue or improve possibility just let me know

Email: ramon_felipe@outlook.com

Discord: Ramon Ferreira#8790
