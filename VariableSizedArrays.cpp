#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;


int main() {
    /* Enter your code here. Read input from STDIN. Print output to STDOUT */   
    int k,q;
    cin >>k>>q;
    vector<vector<int>> arr;
    vector<vector<int>> queries;
    //input
    for(int i = 0; i<k; i++){
        int temp;
        cin >>temp;
        vector<int> arr2;
        
        for(int j=0; j<temp; j++){
            int temp1;
            cin >> temp1;
            arr2.push_back(temp1);
        }
        arr.push_back(arr2);
    }
    for(int i = 0; i<q; i++){
        int index1, index2;
        vector<int> qq;
        cin >> index1 >>index2;
        qq.push_back(index1);
        qq.push_back(index2);
        queries.push_back(qq);
    }
    
    //output
    for(int i = 0; i<queries.size(); i++){
        int n1 = queries[i][0];
        int n2 = queries[i][1];
        int output = arr[n1][n2];
        cout << output << endl;
    }
    return 0;
}
