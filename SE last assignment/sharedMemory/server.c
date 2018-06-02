#include <stdio.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <unistd.h>
#include <string.h>
#include <stdlib.h>

#define TRUE 1

int strLength(char *);
int strCompare(char *,char *);

typedef struct Message{
    char msg[1024];
} Message;

int main(){

    int turn = 3;
    int shm_id;
    size_t size = sizeof(Message)*4;
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
    strcpy(message->msg,name);
    printf("Hello %s\n",name);
    printf("------------------------\n");
    
    strcpy((message+2)->msg,"Welcome");

    printf("Welcome to the chat application\n");
    printf("Server is running on port %d\n",key);

    while(strCompare("Welcome",(message+2)->msg))
        sleep(1);
        
    printf("----------------------------\n");
    printf("%s is now connected \n",(message+1)->msg);
    printf("----------------------------\n");

    strcpy((message+2)->msg,message->msg);
    //message 0 - firstUserInfo
    //message 1 - secondUserInfo
    //message 2 - turn
    //message 3 - message
    while(TRUE){
        if(strCompare(message->msg,(message+2)->msg)){
            printf("%s ----> %s\n",(message+1)->msg,(message+3)->msg);
            printf("Enter your message: ");
            fgets((message+3)->msg,100,stdin);
            printf("%s ----> %s\n",(message)->msg,(message+3)->msg);
            strcpy((message+2)->msg,(message+1)->msg);
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