//#include <stdio.h>
//#include <stdlib.h>

/* run this program using the console pauser or add your own getch, system("pause") or input loop */
//#define _DEBUG false

//ֻ����û�ж��岻��ʵ��ֵ 
/*
int main(int argc, char *argv[]){
    #ifdef _DEBUG
        printf("����ʹ�� Debug ģʽ�������...\n");
    #else
        printf("����ʹ�� Release ģʽ�������...\n");
    #endif

    system("pause");
    return 0;
}*/
//#include <stdio.h>
//#define xx 10086

/*int main(int argc,char *argv[]){
	
	int a = 10,b = 20;
	char c = 'N',d = 'M';
	printf("a==%d,c==%c\n",a,c);
	int *p1 = &a;
	char *p2 = &c;
	printf("p1==%#X,p2==%#X\n",p1,p2);
	/p1 = b;
	/p2 = d;
	p1 = &b;
	p2 = &d;//Ϊʲô�����ǲ��е� 
	printf("p1==%#X,p2==%#X\n",p1,p2);
	printf("a==%d,c==%c\n",a,c);*/
	/*ͨ��ָ���޸�ֵ 
	int a = 15;
	int *p;
	printf("%d\n",a);
	p = &a;
	*p = 100;
	printf("%d\n",a);
	
	//�ַ����������ַ���ָ��Ĳ��
	char *pstr = "name";
	printf("%#X\n",pstr);
	printf("%s\n",pstr);
	char str[30];
	printf("plz ")
	gets(str);
	printf("output == %s\n",str);
	/*int *p = NULL;
	printf("%#X\n",p);	
	printf("%d\n",&p);	
	printf("%d\n",sizeof(p));	
	printf("%d\n",sizeof(int));
	
	char *c = 'c';
	
	printf("%#X\n",c);	
	printf("%d\n",&c);
	printf("%d\n",sizeof(c));
	printf("%d\n",sizeof(char));*/
	

	/*int a[3][4]={{3,17,8,11},{66,7,8,19},{12,88,7,16}};
	int *p,max;
	//for(p=a[0],max=*p;p<a[0]+12;p++)
	for(p=a[0],max=p[0];p<a[0]+12;p++)
	   if(*p>max)
	      max=*p;
	printf("MAX=%d\n",max);*/
	/*int a[4]={3,17,8,11};
	int *p=a,i;
	for(i=0;*p<a+4;i++) {
		printf("i==%d\n",i);
		printf("a==%d\n",*(a+i));
		printf("pointer==%d\n",*p);
		p = (a+i);
		printf("==========\n");
	}
	printf("%d\n",xx);
	const int tempint = 10086;
	int *pint = &tempint;
	printf("%d\n",tempint);
	*pint = 10087;
	
	printf("%d\n",tempint);
	return 0;
}*/
/*
#include <stdio.h>
int main(){
    int a = 15, b = 99, c = 222;
    int *p = &a;  //����ָ�����
    *p = b;  //ͨ��ָ������޸��ڴ��ϵ�����
    c = *p;  //ͨ��ָ�������ȡ�ڴ��ϵ�����
    printf("%d, %d, %d, %d\n", a, b, c, *p);
    return 0;
}*/
