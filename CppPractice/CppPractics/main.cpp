//#include <iostream>
//
///* run this program using the console pauser or add your own getch, system("pause") or input loop */
//
//int main(int argc, char** argv) {
//	return 0;
//}

 #include <iostream>        //��ʮ������ת��Ϊ����������λ�����ȡλ����
 using namespace std;
 int main()
 {
        unsigned short i;
        cout << "������һ��С��65536��������" << endl;
        cin >> i;
        for(int j=15; j >= 0; j--)
        {
               if ( i & ( 1 << j) ) cout << "1";
               else cout << "0";
        }
        printf("\n");
        printf("Values:%d \n", 0x31);
        cout << endl;
		return 0;
 }
