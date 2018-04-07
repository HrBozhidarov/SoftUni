import java.util.LinkedHashMap;
        import java.util.Map;
        import java.util.Scanner;
        import java.util.TreeMap;

public class PhonebookUpgrade {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        TreeMap<String, String> phoneBook = new TreeMap<>();

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

            } else if(command.equals("S")){
                String name = splitLine[1];
                if (phoneBook.containsKey(name)) {
                    System.out.printf("%s -> %s\n", name, phoneBook.get(name));
                } else {
                    System.out.printf("Contact %s does not exist.\n", name);
                }
            }
            else {
                for (Map.Entry<String,String> entry:phoneBook.entrySet()) {
                    System.out.printf("%s -> %s\n", entry.getKey(),entry.getValue());
                }
            }
        }
    }
}
