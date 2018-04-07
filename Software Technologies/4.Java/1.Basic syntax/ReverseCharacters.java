import java.util.Scanner;

public class ReverseCharacters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String firstLetter=scanner.nextLine();
        String secondLetter=scanner.nextLine();
        String thirthLetter=scanner.nextLine();

        System.out.printf("%s%s%s",thirthLetter,secondLetter,firstLetter);
    }
}
