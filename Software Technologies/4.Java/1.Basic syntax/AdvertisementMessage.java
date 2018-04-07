import java.util.Random;
import java.util.Scanner;

public class AdvertisementMessage {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        String[] phrases = {"Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product."};
        String[] events = {"Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"};
        String[] author = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
        String[] cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

        for (int i = 0; i < n; i++) {
            Random randPhrases = new Random();
            int ph=randPhrases.nextInt(phrases.length-1);
            Random randEvents = new Random();
            int ev=randPhrases.nextInt(events.length-1);
            Random randAuthor = new Random();
            int au=randPhrases.nextInt(author.length-1);
            Random randCities = new Random();
            int cit=randPhrases.nextInt(cities.length-1);

            System.out.printf("%s %s %s - %s%n",phrases[ph],events[ev],author[au],cities[cit]);
        }
    }
}
