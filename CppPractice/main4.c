#include <stdlib.h>
#include <stdio.h>
#include "MaxQueue.h"

struct node{
	int data;
	struct node *next;
};

int main(int argc,char *argv[]){
	struct node *head,*p,*q,*t;
	int i,n,a;
	printf("������������");
	//scanf("%d",&n);
	n = 13;
	head = NULL;//��ʼ��ͷ
	printf("����������ÿ���ڵ�����\n");
	for(i = 0;i<n;i++){
		//scanf("%d",&a);
		a = i;
		p = (struct node *)malloc(sizeof(struct node));
		p->data = a;
		p->	next = NULL;
		if(head == NULL){
			head = p;
		} else{
			q->next = p;
		}
		q = p;//������һ���ڵ� 
	} 
	t = head;
	printf("\n");
	while(t!=NULL){
		printf("%d->",t->data);
		t = t->next;
	}
	printf("��ת����\n");
	struct node *a1,*a2,*a3;
	a1 = head;
	a2 = a1->next;
	//0->1->2 
	//2-0
	while(a2->next != NULL){
		a3 = a2->next;
		a2->next = a1;
		a1 = a2;
		a2 = a3;
	}
	head->next = NULL;
	a2->next = a1;
	head = a2;
	printf("\n");
	t = head;
	while(t!=NULL){
		printf("%d->",t->data);
		t = t->next;
	}
	return 0;
}

