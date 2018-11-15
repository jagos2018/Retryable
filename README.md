# Retryable
Simple .NET library to retry logic.

**Wrap Retryable functionality in a separate action**
```
// Run a method as retrable.
List<int> queueItems = Retry.DoAsRetry(PullFromQueue, "id", 5);
````

**Specify conditions that trigger the logic to be retried**
```
public List<int> PullFromQueue(string id, int count) {
  if (id == "") {
    // Specify conditions to Retry on.
    throw new RetryableException();
  } else {
    return new List<int>();
  }
}
````

**License**
MIT
