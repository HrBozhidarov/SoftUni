import java.util.LinkedHashMap;
import java.util.Scanner;

public class Phonebook {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        LinkedHashMap<String, String> phoneBook = new LinkedHashMap<>();

        while (true) {
            String line = scanner.nextLine();

            if (line.equals("END")) {
                break;
            }

            String[] splitLine = line.split(" ");

            String command = splitLine[0];

            if (command.equals("A")) {
                String name = splitLine[1];
                String number = splitLine[2];
                phoneBook.put(name, number);

            } else {
                String name = splitLine[1];
                if (phoneBook.containsKey(name)) {
                    System.out.printf("%s -> %s\n", name, phoneBook.get(name));
                } else {
                    System.out.printf("Contact %s does not exist.\n", name);
                }
            }
        }
    }
}
