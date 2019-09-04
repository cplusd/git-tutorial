/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */
 using System;
public class Solution {
    public int[] TwoSum(int[] nums, int target) {    
       for(int i=0,c=nums.Length;i<c-1;i++)
       {        
          for(int j=i+1;j<c;j++)
          {            
              if(nums[i]+nums[j]==target)
              {             
                return new int[]{i,j};;     
              }
    
          }

       }           
       return null;
    }
}


