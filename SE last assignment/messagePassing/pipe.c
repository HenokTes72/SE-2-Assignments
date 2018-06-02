#include <sys/types.h>
#include <sys/wait.h>
#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>

#define READ 0
#define WRITE 1

int getSquareNumber();

int main() {

    int fd[2];
    int fdd[2];
    pid_t pid;

    pipe(fd);
    pipe(fdd);
    pid = fork();

    if(pid == 0) {
        close(fd[WRITE]);
        close(fdd[READ]);
        int readValue;
        read(fd[READ], &readValue, sizeof(int));

        printf("Initial number is: %d\n", readValue);
        int result = getSquareNumber(readValue);

        write(fdd[WRITE], &result, sizeof(int));

        return result;

    } else if(pid > 0) {
        close(fd[READ]);
        close(fdd[WRITE]);
        int intValue = rand()%20;
        int result;
        if(intValue < 10){
            write(fd[WRITE], &intValue, sizeof(int));
        }
        int re;
        wait(&re);
        read(fdd[READ], &result, sizeof(int));
        printf("Square of %d is: %d\n",intValue,result);
    }
    else{
        printf("ERROR: fork has failed\n");
        exit(-1);
    }

    return 0;
}

int getSquareNumber(int num){
    return num*num;
}