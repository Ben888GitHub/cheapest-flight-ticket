public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        
         //previous state (0 -> k - 1)  to store the cost of flight
        int[] prev = new int[n];
        
        //previous state (0 -> k)  to store the cost of flight
        int[] curr = new int[n];
        
        //Both arrays are initialized to int.MaxVal
        for(int i = 0; i < n; i++){
            prev[i] = int.MaxValue;
            curr[i] = int.MaxValue;
        }
        
        // Initialize source node in prev array to 0 before calculating the min distance between source and other airports coming to react the destination
        prev[src] = 0;
        
        //Run minimum distance from src to dst if max k stops are allowed to take in between
        for(int i = 1; i < k+2; i++){
            //Initialize the cost to reach to source from source to 0
            curr[src] = 0;
            //pass through the flights in the array
            foreach(int[] flight in flights){
                int begin = flight[0];
                int end = flight[1];
                int cost = flight[2];
                
                if(prev[begin] == int.MaxValue){
                    continue;
                }
                curr[end] = Math.Min(curr[end], prev[begin] + cost);
            }
            
            prev = (int[])curr.Clone();
        }
        return curr[dst] == int.MaxValue ? - 1 : curr[dst];
    }
}