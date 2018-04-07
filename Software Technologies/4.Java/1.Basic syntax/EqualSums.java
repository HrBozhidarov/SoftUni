import java.util.Arrays;
import java.util.Scanner;

public class EqualSums {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] seq = Arrays.stream(scanner.nextLine()
                .split(" ")).mapToInt(Integer::parseInt).toArray();

        boolean founNum = false;

        for (int i = 0; i < seq.length; i++) {
            int leftSum = 0;
            int rightSum = 0;

            for (int j = 0; j < i; j++) {
                leftSum += seq[j];
            }

            for (int k = i + 1; k < seq.length; k++) {
                rightSum += seq[k];
            }

            if (leftSum == rightSum) {
                System.out.println(i);
                founNum = true;
            }
        }

        if (!founNum) {
            System.out.println("no");
        }
    }
}
