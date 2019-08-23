#include <stdio.h>
#include <stdlib.h>

#define Data int
typedef struct{
	Data data;
}ElemType;

typedef struct{
	ElemType *Elems;
	int Length;
}ArrayData;

void Create(ArrayData **table,int length){
	(*table) = (ArrayData *)malloc(sizeof(ArrayData));
	(*table)->Length = length;
	(*table)->Elems = (ElemType *)malloc(sizeof(ElemType)*(length+1));
	printf("����������\n");
	int i = 1;
	for(;i<length+1;i++){
		scanf("%d",&((*table)->Elems[i].data));
	}
}

void CreateV1(ArrayData **st,int length){
    (*st)=(ArrayData*)malloc(sizeof(ArrayData));
    (*st)->Length=length;
    (*st)->Elems =(ElemType*)malloc((length+1)*sizeof(ElemType));
    printf("������е�����Ԫ�أ�\n");
    //���ݲ��ұ�������Ԫ�ص��ܳ��ȣ��ڴ洢ʱ���������±�Ϊ 1 �Ŀռ俪ʼ�洢����
    int i;
    for (i=1; i<=length; i++) {
        scanf("%d",&((*st)->Elems[i].data));
    }
}

void CreateV2(ArrayData *table,int length){
	(table) = (ArrayData *)malloc(sizeof(ArrayData));
	(table)->Length = length;
	(table)->Elems = (ElemType *)malloc(sizeof(ElemType)*(length+1));
	printf("����������");
	int i = 1;
	for(;i<length+1;i++){
		scanf("%d",&((table)->Elems[i].data));
	}
}

void Vlog (ArrayData **data){
	int i;
	printf("vlog start==>%d\n",(*data)->Length);
	for(i = (*data)->Length;i>-1;i--){
		printf("max vlog %d==>%d\n",i,(*data)->Elems[i]);
	}
}


int mainArrayinput(int argv,char *argc){
 	printf("hello maxwell");
 	printf("���������ݳ���");
 	int len = 0;
 	scanf("%d",&len);
 	ArrayData *array;
 	//Create(&array,len);
 	CreateV1(&array,len);
 	Vlog(&array);
 	return 0;
 } 
 
 //*************
//#include <stdio.h>
//#include <stdlib.h>
//#define keyType int
//typedef struct {
//    keyType key;//���ұ���ÿ������Ԫ�ص�ֵ
//    //�����Ҫ��������������������
//}ElemType;
//
//typedef struct{
//    ElemType *elem;//��Ų��ұ�������Ԫ�ص�����
//    int length;//��¼���ұ������ݵ�������
//}SSTable;
////�������ұ�
//void Create(SSTable **st,int length){
//    (*st)=(SSTable*)malloc(sizeof(SSTable));
//    (*st)->length=length;
//    (*st)->elem =(ElemType*)malloc((length+1)*sizeof(ElemType));
//    printf("������е�����Ԫ�أ�\n");
//    //���ݲ��ұ�������Ԫ�ص��ܳ��ȣ��ڴ洢ʱ���������±�Ϊ 1 �Ŀռ俪ʼ�洢����
//    for (int i=1; i<=length; i++) {
//        scanf("%d",&((*st)->elem[i].key));
//    }
//}
////���ұ����ҵĹ��ܺ���������keyΪ�ؼ���
//int Search_seq(SSTable *st,keyType key){
//    st->elem[0].key=key;//���ؼ�����Ϊһ������Ԫ�ش�ŵ����ұ��ĵ�һ��λ�ã�������ڵ�����
//    int i=st->length;
//    //�Ӳ��ұ������һ������Ԫ�����α�����һֱ�����������±�Ϊ0
//    while (st->elem[i].key!=key) {
//        i--;
//    }
//    //��� i=0��˵������ʧ�ܣ���֮�����ص��Ǻ��йؼ���key������Ԫ���ڲ��ұ��е�λ��
//    return i;
//}
//int main(int argc, const char * argv[]) {
//    SSTable *st;
//    Create(&st, 6);
//    getchar();
//    printf("������������ݵĹؼ��֣�\n");
//    int key;
//    scanf("%d",&key);
//    int location=Search_seq(st, key);
//    if (location==0) {
//        printf("����ʧ��");
//    }else{
//        printf("�����ڲ��ұ��е�λ��Ϊ��%d",location);
//    }
//    return 0;
//}