import java.util.Arrays;
import java.util.Scanner;

public class MostFrequentNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] seq = Arrays.stream(scanner.nextLine()
                .split(" ")).mapToInt(Integer::parseInt).toArray();
        int count=0;
        int value=0;

        for(int i=0;i<seq.length;i++) {
            int currentNumber=seq[i];
            int currentCount=0;

            for(int j=i;j<seq.length;j++) {
                if (currentNumber==seq[j]) {
                    currentCount++;
                }
            }

            if(currentCount>count) {
                count=currentCount;
                value=currentNumber;
            }
        }

        System.out.print(value);
    }
}
