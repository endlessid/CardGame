using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeightedRandomization
{
    public static IWeighted Choose(List<IWeighted> list)
    {
		int totalweight = 0;
		foreach(IWeighted iw in list){
			totalweight += iw.Weight;	
		}
        int choice = Random.Range(0, totalweight);
        int sum = 0;

        foreach (IWeighted obj in list)
        {
            for (int i = sum; i < obj.Weight + sum; i++)
            {
                if (i >= choice)
                {
                    return obj;
                }
            }
            sum += obj.Weight;
        }
        return null;
    }
	
	public static IWeighted[] MultiChoose(List<IWeighted> list, int count)
    {	
		
		count = count > list.Count? list.Count : count; 
		
		IWeighted[] _result = new IWeighted[count];
		int _index = 0;
		for(int i = 0 ; i < count ; i++){
			IWeighted choice = Choose(list);
			_result[_index] = choice;
			_index++;
			list.Remove(choice);
		}

        return _result;
    }
	
	public static void Test(){
		
		List<int> itemList = new List<int>();
		itemList.Add(100);	//0
		itemList.Add(50);	//1
		//itemList.Add(50);	//2
		//itemList.Add(50);	//3
		//itemList.Add(100);	//4
		//itemList.Add(10000);	//
		
		List<IWeighted> list=new List<IWeighted>();
		
		for(int i = 0 ; i < itemList.Count; i++){
        	list.Add(new IWeighted{Id=i,Weight=itemList[i]});
		}
		
		IWeighted[] randomSelectedObject =  WeightedRandomization.MultiChoose(list,3) as IWeighted[];
		foreach(IWeighted iw in randomSelectedObject){
			Debug.Log(iw.Id);
		}
	}
}
/*
public interface IWeighted
{
    int Weight { get; set; }
}*/

public class IWeighted //: IWeighted
{
    private int _id;

    private int _weight;

    public int Id
    {
        get
        {
            return this._id;
        }
        set
        {
            this._id=value;
        }
    }

    public int Weight
    {
        get
        {
            return this._weight;
        }
        set
        {
            this._weight=value;
        }

    }
}