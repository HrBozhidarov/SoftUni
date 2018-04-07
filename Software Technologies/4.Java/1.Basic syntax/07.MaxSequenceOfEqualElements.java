import java.util.Scanner;

public class MaxSequenceOfEqualElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] seq = scanner.nextLine().split(" ");
        int bestPosition = 0;
        int bestLength = 0;
        int currentLength = 0;
        int currentPosition = 0;

        for (int i = 0; i < seq.length - 1; i++) {
            if (seq[i].equals(seq[i + 1])) {
                if (currentLength == 0) {
                    currentLength = 1;
                    currentPosition = i;
                }
                currentLength++;
            } else {
                if (currentLength > bestLength) {
                    bestLength = currentLength;
                    bestPosition = currentPosition;
                }
                currentLength = 0;
            }
        }

        if (currentLength > bestLength) {
            bestLength = currentLength;
            bestPosition = currentPosition;
        }

        for (int i = bestPosition; i < bestLength + bestPosition; i++) {
            System.out.print(seq[i] + " ");
        }
    }
}
