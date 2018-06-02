#include <stdio.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>

int strLength(char *);
int strCompare(char *,char *);

#define TRUE 1

typedef struct Message{
    char msg[1024];
} Message;

int main(){

    int turn = 4;
    int shm_id;
    size_t size = sizeof(Message)*10;
    int shmflg = IPC_CREAT | 0666;

    key_t key = 12345;
    Message *message;

    shm_id = shmget(key, size, shmflg);
    if(shm_id == -1){
        perror("ERROR: shmget has failed\n");
        exit(0);
    }
    message = shmat(shm_id, NULL, 0);
    if(message == (void *)-1){
        perror("ERROR: shmat has failed\n");
        exit(0);
    }

    char name[50];
    printf("Enter your name: ");
    scanf("%s",name);
    printf("Hello %s\n",name);
    strcpy((message+1)->msg,name);
    strcpy((message+2)->msg,name);

    printf("------------------------\n");
    printf("%s is now online\n", message->msg);
    printf("------------------------\n");

    strcpy((message+2)->msg,message->msg);

    while(TRUE){
        if(strCompare((message+1)->msg,(message+2)->msg)){
            printf("%s ----> %s\n",(message)->msg,(message+3)->msg);
            printf("Enter your message: ");
            fgets((message+3)->msg,100,stdin);
            printf("%s ----> %s\n",(message+1)->msg,(message+3)->msg);
            strcpy((message+2)->msg,(message)->msg);
        }
        else{
            sleep(1);
        }

    }
    
    //printf("The value changed by the second process is %.2f\n",*double_value);
    
    if(shmdt(message) == -1){
        perror("ERROR: shmdt has failed \n");
    }

    shmctl(shm_id,IPC_RMID,NULL);

    return 0;
}

int strCompare(char *firstString,char *secondString){
    int firstStringLength = strLength(firstString);
    int result = 1;
    for(int j=0;j<firstStringLength;j++){
        if(firstString[j] != secondString[j]){
            result = 0;
            break;
        }
    }
    return result;
}

int strLength(char *str){
    int length = 0;
    while(*str++ != '\0'){
        length += 1;
    }
    return length;
}
