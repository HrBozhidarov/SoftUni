import java.util.HashMap;
import java.util.Scanner;

public class IndexOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        HashMap<Character, Integer> hashMap = new HashMap<>();

        for (int i = 0; i <= 25; i++) {
            hashMap.put((char)(97+i),i);
        }

        String line = scanner.nextLine();

        for (int i=0;i<line.length();i++) {
            System.out.printf("%s -> %d%n",line.charAt(i),hashMap.get(line.charAt(i)));
            hashMap.get(line.charAt(i));
        }
    }
}
